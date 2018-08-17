using System;
using System.Runtime.InteropServices;
using Internal.Runtime.CompilerServices;
using System.Runtime.Serialization;

struct JsonDelegateEntry
{
    public bool IsCollection;
    public int DataContractMapIndex;        // indexes into s_dataContractMap
    public IntPtr WriterDelegate;
    public IntPtr ReaderDelegate;
    public IntPtr GetOnlyReaderDelegate;
}

namespace System.Runtime.Serialization.Generated
{
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.Xml;
    using System.Runtime.CompilerServices;

    using TodoList = System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<DataContract, int>>;

    public static partial class DataContractSerializerHelper
    {
        static JsonDelegateEntry[] JsonDelegatesList { get { return s_jsonDelegatesList; } }

        public static void PopulateJsonDelegateDictionary(
            Dictionary<Type, DataContract> dataContracts,                   // not modified
            Dictionary<DataContract, JsonReadWriteDelegates> jsonDelegates) // modified
        {
            for (int i = 0; i < JsonDelegatesList.Length; i++)
            {
                int mapIndex = JsonDelegatesList[i].DataContractMapIndex;
                Type userType = Type.GetTypeFromHandle(DataContractMap[mapIndex].UserCodeType.RuntimeTypeHandle);
                DataContract contract = dataContracts[userType];
                JsonReadWriteDelegates delegates;

                if (JsonDelegatesList[i].IsCollection)
                {
                    delegates = new JsonReadWriteDelegates
                    {
                        CollectionWriterDelegate = (JsonFormatCollectionWriterDelegate)DelegateFromIntPtr(typeof(JsonFormatCollectionWriterDelegate), JsonDelegatesList[i].WriterDelegate),
                        CollectionReaderDelegate = (JsonFormatCollectionReaderDelegate)DelegateFromIntPtr(typeof(JsonFormatCollectionReaderDelegate), JsonDelegatesList[i].ReaderDelegate),
                        GetOnlyCollectionReaderDelegate = (JsonFormatGetOnlyCollectionReaderDelegate)DelegateFromIntPtr(typeof(JsonFormatGetOnlyCollectionReaderDelegate), JsonDelegatesList[i].GetOnlyReaderDelegate),
                    };
                }
                else
                {
                    delegates = new JsonReadWriteDelegates
                    {
                        ClassWriterDelegate = (JsonFormatClassWriterDelegate)DelegateFromIntPtr(typeof(JsonFormatClassWriterDelegate), JsonDelegatesList[i].WriterDelegate),
                        ClassReaderDelegate = (JsonFormatClassReaderDelegate)DelegateFromIntPtr(typeof(JsonFormatClassReaderDelegate), JsonDelegatesList[i].ReaderDelegate),
                    };
                }

                if (!jsonDelegates.ContainsKey(contract))
                {
                    jsonDelegates.Add(contract, delegates);
                }
            }
        }
    }
}
