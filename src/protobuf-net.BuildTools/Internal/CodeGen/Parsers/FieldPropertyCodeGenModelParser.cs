﻿using Microsoft.CodeAnalysis;
using ProtoBuf.BuildTools.Internal;
using ProtoBuf.Internal.CodeGen.Parsers.Common;
using ProtoBuf.Internal.CodeGen.Providers;
using ProtoBuf.Reflection.Internal.CodeGen;

namespace ProtoBuf.Internal.CodeGen.Parsers;

internal sealed class FieldPropertyCodeGenModelParser : PropertyCodeGenModelParserBase<CodeGenField>
{
    public FieldPropertyCodeGenModelParser(SymbolCodeGenModelParserProvider parserProvider) : base(parserProvider)
    {
    }
    
    public override CodeGenField Parse(IPropertySymbol symbol)
    {
        var propertyAttributes = symbol.GetAttributes();
        if (IsProtoMember(propertyAttributes, out var protoMemberAttribute))
        {
            var (fieldNumber, originalName, dataFormat) = GetProtoMemberAttributeData(protoMemberAttribute);
            var codeGenField = new CodeGenField(fieldNumber, symbol.Name)
            {
                OriginalName = originalName,
                Type = ResolveCodeGenType(symbol, dataFormat)
            };
        
            return codeGenField;
        }

        // throw exception here ?
        return null;
    }

    private CodeGenType ResolveCodeGenType(IPropertySymbol symbol, DataFormat? dataFormat)
    {
        var simpleCodeGenType = symbol.ResolveCodeGenType(dataFormat);
        return simpleCodeGenType ?? ParseContext.GetContractType(symbol.GetFullyQualifiedType());
    }
}