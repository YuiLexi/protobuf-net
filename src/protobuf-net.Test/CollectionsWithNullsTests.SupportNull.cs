﻿using ProtoBuf.Meta;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ProtoBuf.Test
{
    // 2. if model *is* tweaked with SupportNull, then: 
    //  2a. schema has new wrapper layer, "message Foo { repeated NullWrappedBar Items = 1; }" 
    //      with "group Bar value = 1" **invalid** syntax
    //  2b. payload has the extra layer with "group"
    //  2c. null works correctly! 
    public partial class CollectionsWithNullsTests
    {
        private static void AdjustRuntimeTypeModel()
        {
            RuntimeTypeModel.Default[typeof(SupportsNullListModel)][1].SupportNull = true;
        }

        [Fact]
        public void ProtoSchema_SupportsNullModelClass()
        {
            AssertSchemaSections<SupportsNullListModel>(
                "message Bar { }",
                "message WrappedBar { group Bar value = 1; }",
                "message SupportsNullListModel { repeated WrappedBar Items = 1;}"
            );
        }

        [Fact]
        public void SupportsNullModel_ByteOutput()
        {
            var model = SupportsNullListModel.Build();
            var hex = GetSerializationOutputHex(model);
            Assert.Equal("0B-0A-00-0C-0B-0A-00-0C", hex);
        }

        [Fact]
        public void ProtoSerializationWithNulls_SupportsNullModel_Fails()
        {
            var model = SupportsNullListModel.BuildWithNull();
            var ms = new MemoryStream();
            
            // runs with no exceptions raised
            Serializer.Serialize(ms, model);
        }

        [ProtoContract]
        class SupportsNullListModel
        {
            [ProtoMember(1)]
            public List<Bar?> Items { get; set; } = new();

            public static SupportsNullListModel Build() => new()
            {
                Items = new()
                {
                    new Bar { Id = 1 }, new Bar { Id = 2 }
                }
            };

            public static SupportsNullListModel BuildWithNull() => new()
            {
                Items = new()
                {
                    new Bar { Id = 1 }, null, new Bar { Id = 2 }
                }
            };
        }
    }
}
