using System;
using System.Runtime.InteropServices;
using Internal.Runtime.CompilerServices;
using System.Runtime.Serialization;

enum DataContractKind
{
    Unknown                  ,
    BooleanDataContract      ,
    ByteArrayDataContract    ,
    CharDataContract         ,
    DateTimeDataContract     ,
    DecimalDataContract      ,
    DoubleDataContract       ,
    FloatDataContract        ,
    GuidDataContract         ,
    IntDataContract          ,
    LongDataContract         ,
    ObjectDataContract       ,
    QNameDataContract        ,
    ShortDataContract        ,
    SignedByteDataContract   ,
    StringDataContract       ,
    TimeSpanDataContract     ,
    UnsignedByteDataContract ,
    UnsignedIntDataContract  ,
    UnsignedLongDataContract ,
    UnsignedShortDataContract,
    UriDataContract          ,
    InvalidDataContract      ,
};

struct CommonContractEntry
{
    public bool HasRoot;
    public bool IsBuiltInDataContract;
    public bool IsISerializable;
    public bool IsReference;
    public bool IsValueType;
    public bool TypeIsCollectionInterface;
    public bool TypeIsInterface;
    public int NameIndex;
    public int NamespaceIndex;
    public int StableNameIndex;
    public int StableNameNamespaceIndex;
    public int TopLevelElementNameIndex;
    public int TopLevelElementNamespaceIndex;
    public int KnownDataContractsListIndex;     // indexes into s_knownContractsLists array, -1 terminated
    public FixupRuntimeTypeHandle OriginalUnderlyingType;
    public FixupRuntimeTypeHandle UnderlyingType;
    public FixupRuntimeTypeHandle GenericTypeDefinition;
}

// PrimitiveDataContract / InvalidDataContract
struct DataContractEntry
{
    public CommonContractEntry Common;

    public int ErrorMessageIndex;
    public DataContractKind Kind;
}

struct ClassDataContractEntry
{
    public CommonContractEntry Common;

    // ClasssDataContract / CollectionDataContract
    public IntPtr XmlFormatReaderDelegate;
    public IntPtr XmlFormatWriterDelegate;

    // ClassDataContract
    public bool HasDataContract;
    public bool HasExtensionData;
    public int ChildElementNamespacesListIndex; // indexes into s_xmlDictionaryStrings array, -1 terminated
    public int ContractNamespacesListIndex;     // indexes into s_xmlDictionaryStrings array, -1 terminated
    public int MemberNamesListIndex;            // indexes into s_xmlDictionaryStrings array, -1 terminated
    public int MemberNamespacesListIndex;       // indexes into s_xmlDictionaryStrings array, -1 terminated
}

struct CollectionDataContractEntry
{
    public CommonContractEntry Common;

    // ClasssDataContract / CollectionDataContract
    public IntPtr XmlFormatReaderDelegate;
    public IntPtr XmlFormatWriterDelegate;

    // CollectionDataContract
    public CollectionKind CollectionContractKind;
    public int CollectionItemNameIndex;
    public int KeyNameIndex;
    public int ItemNameIndex;
    public int ValueNameIndex;
    public FixupRuntimeTypeHandle ItemType;
    public IntPtr XmlFormatGetOnlyCollectionReaderDelegate;
}

struct EnumDataContractEntry
{
    public CommonContractEntry Common;

    // EnumDataContract
    public bool IsFlags;
    public bool IsULong;
    public int BaseContractNameIndex;
    public int BaseContractNamespaceIndex;
    public int ChildElementNamesListIndex;      // indexes into s_xmlDictionaryStrings array, -1 terminated

    public int MemberCount;
    public int MemberListIndex;
}

struct XmlDataContractEntry
{
    public CommonContractEntry Common;

    // XmlDataContract
    public IntPtr CreateXmlSerializableDelegate;
}

struct MemberEntry
{
    public bool EmitDefaultValue;
    public bool HasConflictingNameAndType;
    public bool IsGetOnlyCollection;
    public bool IsNullable;
    public bool IsRequired;
    public int Order;
    public int NameIndex;
    public long Value;
}

struct DataContractMapEntry
{
    public FixupRuntimeTypeHandle UserCodeType;
    public int TableIndex; // (index_in_table << 4) | table_index
}

namespace System.Runtime.CompilerServices
{
    internal sealed class __BlockReflectionAttribute : global::System.Attribute
    {
    }
}

namespace System.Runtime.InteropServices
{
    [AttributeUsage((System.AttributeTargets.Method | System.AttributeTargets.Class))]
    internal class McgIntrinsicsAttribute : Attribute
    {
    }
}

[McgIntrinsics]
static class SgIntrinsics
{
    internal static IntPtr AddrOf<T>(T ftn)
    {
        // This method is implemented elsewhere in the toolchain
        return default(IntPtr);
    }
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

    [global::System.Runtime.CompilerServices.ModuleConstructor]
    [global::System.Runtime.CompilerServices.DependencyReductionRoot]
    public static partial class DataContractSerializerHelper
    {
        // ROOTS
        //      s_dataContractMap
        //          s_dataContracts
        //          s_classDataContracts
        //          s_collectionDataContracts
        //          s_enumDataContracts
        //          s_xmlDataContracts
        //      s_jsonDelegatesList
        //
        // POOLS
        //      s_stringPool
        //      s_xmlDictionaryStrings
        //      s_dataMemberLists
        //      s_knownContractsLists

        static DataContractMapEntry[]           DataContractMap         { get { return s_dataContractMap; } }
        static DataContractEntry[]              DataContracts           { get { return s_dataContracts; } }
        static ClassDataContractEntry[]         ClassDataContracts      { get { return s_classDataContracts; } }
        static CollectionDataContractEntry[]    CollectionDataContracts { get { return s_collectionDataContracts;  } }
        static EnumDataContractEntry[]          EnumDataContracts       { get { return s_enumDataContracts; } }
        static XmlDataContractEntry[]           XmlDataContracts        { get { return s_xmlDataContracts; } }
        static char[]                           StringPool              { get { return s_stringPool; } }
        static int[]                            XmlDictionaryStrings    { get { return s_xmlDictionaryStrings; } }
        static MemberEntry[]                    DataMemberLists         { get { return s_dataMemberLists; } }
        static int[]                            KnownContractLists      { get { return s_knownContractsLists; } }

        static DataContractSerializerHelper()
        {
            // This method is generated by the code and it will call PopulateContractDictionary and also
            // possibly PopulateJsonDelegateDictionary and PopulateWcfSerializerDictionary.
            InitDataContracts();
        }

        public static void PopulateContractDictionary(
                        Dictionary<Type, DataContract> dataContracts)
        {
            // fill in dictionaries from pre-initialized data

            XmlDictionary xmlDict = new XmlDictionary();
            TodoList knownContractsTodoList = new TodoList();
            for (int i = 0; i < DataContractMap.Length; i++)
            {
                int encodedTableIndex = DataContractMap[i].TableIndex;
                Type type = Type.GetTypeFromHandle(DataContractMap[i].UserCodeType.RuntimeTypeHandle);
                DataContract decodedContract = DecodeContract(encodedTableIndex, xmlDict, knownContractsTodoList);
                if (!type.IsRemovedByDR())
                {
                    // In scenarios where we try to register two contracts for the same type it should not matter
                    // which one we use as they should be identical in functionality. This relies on the assumption
                    // that the serialization code gen will produce functionaly the same code for the same input type.
                    if (!dataContracts.ContainsKey(type))
                    {
                        dataContracts.Add(type, decodedContract);
                    }
                }

                // Silly optimization to mimick previous implementation:  If the next entry refers to the same data
                // contract, let's add that one to the map too without decoding a new DataContract instance.
                if (((i + 1) < DataContractMap.Length)
                    && (DataContractMap[i + 1].TableIndex == encodedTableIndex))
                {
                    Type otherType = Type.GetTypeFromHandle(DataContractMap[i + 1].UserCodeType.RuntimeTypeHandle);
                    if (!otherType.IsRemovedByDR())
                    {
                        if (!dataContracts.ContainsKey(otherType))
                        {
                            dataContracts.Add(otherType, decodedContract);
                        }
                    }
                    i++;
                }
            }

            foreach (KeyValuePair<DataContract, int> entry in knownContractsTodoList)
            {
                DataContract contract = entry.Key;
                int knownDataContractsListIndex = entry.Value;

                contract.KnownDataContracts = DecodeKnownContractsList(dataContracts, knownDataContractsListIndex);
            }
        }

        static int DecodeTableIndex(int encodedTableIndex, out int whichTable)
        {
            whichTable = encodedTableIndex & 0xF;
            return encodedTableIndex >> 4;
        }

        static DataContract DecodeContract(int encodedTableIndex, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            int whichTable;
            int indexWithinTable = DecodeTableIndex(encodedTableIndex, out whichTable);
            switch (whichTable)
            {
                case 0: return DecodeDataContract(indexWithinTable, xmlDict, knownContractsTodoList);
                case 1: return DecodeClassDataContract(indexWithinTable, xmlDict, knownContractsTodoList);
                case 2: return DecodeCollectionDataContract(indexWithinTable, xmlDict, knownContractsTodoList);
                case 3: return DecodeEnumDataContract(indexWithinTable, xmlDict, knownContractsTodoList);
                case 4: return DecodeXmlDataContract(indexWithinTable, xmlDict, knownContractsTodoList);
                default:
                    throw new Exception("unexpected table index");
            }
        }

        static DataContract DecodeDataContract(int index, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            DataContract contract = AllocateSimpleDataContract(DataContracts[index].Kind);
            DecodeCommon(xmlDict, contract, ref DataContracts[index].Common, knownContractsTodoList);

            if (contract is InvalidDataContract)
            {
                ((InvalidDataContract)contract).ErrorMessage = GetString(DataContracts[index].ErrorMessageIndex);
            }

            return contract;
        }

        static DataContract DecodeClassDataContract(int index, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            ClassDataContract contract = new ClassDataContract();

            DecodeCommon(xmlDict, contract, ref ClassDataContracts[index].Common, knownContractsTodoList);

            contract.XmlFormatReaderDelegate = (XmlFormatClassReaderDelegate)DelegateFromIntPtr(typeof(XmlFormatClassReaderDelegate), ClassDataContracts[index].XmlFormatReaderDelegate);
            contract.XmlFormatWriterDelegate = (XmlFormatClassWriterDelegate)DelegateFromIntPtr(typeof(XmlFormatClassWriterDelegate), ClassDataContracts[index].XmlFormatWriterDelegate);
            contract.HasDataContract         = ClassDataContracts[index].HasDataContract;
            contract.HasExtensionData        = ClassDataContracts[index].HasExtensionData;
            contract.ChildElementNamespaces  = DecodeDictStringList(xmlDict, ClassDataContracts[index].ChildElementNamespacesListIndex);
            contract.ContractNamespaces      = DecodeDictStringList(xmlDict, ClassDataContracts[index].ContractNamespacesListIndex);
            contract.MemberNames             = DecodeDictStringList(xmlDict, ClassDataContracts[index].MemberNamesListIndex);
            contract.MemberNamespaces        = DecodeDictStringList(xmlDict, ClassDataContracts[index].MemberNamespacesListIndex);

            return contract;
        }

        static DataContract DecodeCollectionDataContract(int index, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            CollectionDataContract contract = new CollectionDataContract(CollectionDataContracts[index].CollectionContractKind);

            DecodeCommon(xmlDict, contract, ref CollectionDataContracts[index].Common, knownContractsTodoList);

            contract.XmlFormatReaderDelegate = (XmlFormatCollectionReaderDelegate)DelegateFromIntPtr(typeof(XmlFormatCollectionReaderDelegate), CollectionDataContracts[index].XmlFormatReaderDelegate);
            contract.XmlFormatWriterDelegate = (XmlFormatCollectionWriterDelegate)DelegateFromIntPtr(typeof(XmlFormatCollectionWriterDelegate), CollectionDataContracts[index].XmlFormatWriterDelegate);
            contract.CollectionItemName      = GetDictString(xmlDict, CollectionDataContracts[index].CollectionItemNameIndex);
            contract.KeyName                 = GetString(CollectionDataContracts[index].KeyNameIndex);
            contract.ItemName                = GetString(CollectionDataContracts[index].ItemNameIndex);
            contract.ValueName               = GetString(CollectionDataContracts[index].ValueNameIndex);
            contract.ItemType                = Type.GetTypeFromHandle(CollectionDataContracts[index].ItemType.RuntimeTypeHandle);
            contract.XmlFormatGetOnlyCollectionReaderDelegate = (XmlFormatGetOnlyCollectionReaderDelegate)DelegateFromIntPtr(typeof(XmlFormatGetOnlyCollectionReaderDelegate), CollectionDataContracts[index].XmlFormatGetOnlyCollectionReaderDelegate);

            return contract;
        }

        static DataContract DecodeEnumDataContract(int index, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            List<long> values;
            EnumDataContract contract = new EnumDataContract();

            DecodeCommon(xmlDict, contract, ref EnumDataContracts[index].Common, knownContractsTodoList);

            contract.IsFlags           = EnumDataContracts[index].IsFlags;
            contract.IsULong           = EnumDataContracts[index].IsULong;
            contract.BaseContractName  = GetQualifiedName(EnumDataContracts[index].BaseContractNameIndex, EnumDataContracts[index].BaseContractNamespaceIndex);
            contract.ChildElementNames = DecodeDictStringList(xmlDict, EnumDataContracts[index].ChildElementNamesListIndex);
            contract.Members           = DecodeMembersAndValues(EnumDataContracts[index].MemberCount, EnumDataContracts[index].MemberListIndex, out values);
            contract.Values            = values;

            return contract;
        }

        static DataContract DecodeXmlDataContract(int index, XmlDictionary xmlDict, TodoList knownContractsTodoList)
        {
            XmlDataContract contract = new XmlDataContract();

            DecodeCommon(xmlDict, contract, ref XmlDataContracts[index].Common, knownContractsTodoList);

            contract.CreateXmlSerializableDelegate = (CreateXmlSerializableDelegate)DelegateFromIntPtr(typeof(CreateXmlSerializableDelegate), XmlDataContracts[index].CreateXmlSerializableDelegate);

            return contract;
        }

        static Delegate DelegateFromIntPtr(Type delegateType, IntPtr pfnStaticManagedMethod)
        {
            if (pfnStaticManagedMethod == IntPtr.Zero)
                return null;

            return FunctionPointerHelpers.UnsafeDelegateFromStaticMethodFunctionPointer(delegateType, pfnStaticManagedMethod);
        }

        //
        // These decode methods are factored out in the hopes that the compiler will fold them together, as they should
        // be identical code since they only vary by the type of the second parameter and the layout of those structs
        // should match for the fields being accessed
        //
        static void DecodeCommon(XmlDictionary xmlDict, DataContract contract, ref CommonContractEntry entry, TodoList knownContractsTodoList)
        {
            contract.HasRoot                    = entry.HasRoot;
            contract.IsBuiltInDataContract      = entry.IsBuiltInDataContract;
            if (entry.IsISerializable)
            {
                // Only classes can be generated as ISerializable.
                contract.IsISerializable = entry.IsISerializable;
            }

            contract.IsReference                = entry.IsReference;
            contract.IsValueType                = entry.IsValueType;
            contract.TypeIsCollectionInterface  = entry.TypeIsCollectionInterface;
            contract.TypeIsInterface            = entry.TypeIsInterface;
            contract.Name                       = GetDictString(xmlDict, entry.NameIndex);
            contract.Namespace                  = GetDictString(xmlDict, entry.NamespaceIndex);
            contract.StableName                 = GetQualifiedName(entry.StableNameIndex, entry.StableNameNamespaceIndex);
            contract.TopLevelElementName        = GetDictString(xmlDict, entry.TopLevelElementNameIndex);
            contract.TopLevelElementNamespace   = GetDictString(xmlDict, entry.TopLevelElementNamespaceIndex);
            contract.OriginalUnderlyingType     = Type.GetTypeFromHandle(entry.OriginalUnderlyingType.RuntimeTypeHandle);
            contract.UnderlyingType             = Type.GetTypeFromHandle(entry.UnderlyingType.RuntimeTypeHandle);
            contract.GenericTypeDefinition      = Type.GetTypeFromHandle(entry.GenericTypeDefinition.RuntimeTypeHandle);

            knownContractsTodoList.Add(new KeyValuePair<DataContract, int>(contract, entry.KnownDataContractsListIndex));
        }

        unsafe static string GetString(int stringPoolIndex)
        {
            if (stringPoolIndex == -1)
                return null;

            fixed (char* pData = &StringPool[stringPoolIndex])
            {
                return new string(pData);
            }
        }

        static XmlDictionaryString GetDictString(XmlDictionary xmlDict, int stringPoolIndex)
        {
            if (stringPoolIndex == -1)
                return null;

            return xmlDict.Add(GetString(stringPoolIndex));
        }

        static XmlQualifiedName GetQualifiedName(int nameIndex, int namespaceIndex)
        {
            if (nameIndex == -1)
                return null;
            return new XmlQualifiedName(GetString(nameIndex), GetString(namespaceIndex));
        }

        static XmlDictionaryString[] DecodeDictStringList(XmlDictionary xmlDict, int listIndex)
        {
            int curIndex = listIndex;
            int length = XmlDictionaryStrings[curIndex++];
            XmlDictionaryString[] result = new XmlDictionaryString[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = GetDictString(xmlDict, XmlDictionaryStrings[curIndex++]);
            }
            return result;
        }

        static List<DataMember> DecodeMembersAndValues(int memberCount, int memberListIndex, out List<long> values)
        {
            List<DataMember> members = new List<DataMember>(memberCount);
            values = new List<long>(memberCount);
            for (int i = memberListIndex; i < (memberListIndex + memberCount); i++)
            {
                DataMember member = new DataMember();

                member.EmitDefaultValue          = DataMemberLists[i].EmitDefaultValue;
                member.HasConflictingNameAndType = DataMemberLists[i].HasConflictingNameAndType;
                member.IsGetOnlyCollection       = DataMemberLists[i].IsGetOnlyCollection;
                member.IsNullable                = DataMemberLists[i].IsNullable;
                member.IsRequired                = DataMemberLists[i].IsRequired;
                member.Order                     = DataMemberLists[i].Order;
                member.Name                      = GetString(DataMemberLists[i].NameIndex);

                members.Add(member);

                values.Add(DataMemberLists[i].Value);
            }
            return members;
        }

        static Dictionary<XmlQualifiedName, DataContract> DecodeKnownContractsList(
            Dictionary<Type, DataContract> dataContracts,
            int knownDataContractsListIndex)
        {
            Dictionary<XmlQualifiedName, DataContract> result = new Dictionary<XmlQualifiedName, DataContract>();

            int curListIndex = knownDataContractsListIndex;
            int mapIndex = KnownContractLists[curListIndex++];
            while (mapIndex != -1)
            {
                // The list entries are indexes into the DataContractMap
                Type type = Type.GetTypeFromHandle(DataContractMap[mapIndex].UserCodeType.RuntimeTypeHandle);

                // All contracts have been loaded now, so we fetch the referenced contract from the passed-in collection
                // using it's user type as the key. 
                DataContract otherContract = dataContracts[type];

                // Now form the key for the KnownDataContracts dictionary
                XmlQualifiedName otherContractKey 
                    = new XmlQualifiedName(otherContract.Name.Value, otherContract.Namespace.Value);

                // And add the entry to the KnownDataContracts dictionary
                result.Add(otherContractKey, otherContract);

                mapIndex = KnownContractLists[curListIndex++];
            }

            return result;
        }

        static DataContract AllocateSimpleDataContract(DataContractKind kind)
        {
            switch (kind)
            {
                case DataContractKind.BooleanDataContract       : return new BooleanDataContract      ();
                case DataContractKind.ByteArrayDataContract     : return new ByteArrayDataContract    ();
                case DataContractKind.CharDataContract          : return new CharDataContract         ();
                case DataContractKind.DateTimeDataContract      : return new DateTimeDataContract     ();
                case DataContractKind.DecimalDataContract       : return new DecimalDataContract      ();
                case DataContractKind.DoubleDataContract        : return new DoubleDataContract       ();
                case DataContractKind.FloatDataContract         : return new FloatDataContract        ();
                case DataContractKind.GuidDataContract          : return new GuidDataContract         ();
                case DataContractKind.IntDataContract           : return new IntDataContract          ();
                case DataContractKind.LongDataContract          : return new LongDataContract         ();
                case DataContractKind.ObjectDataContract        : return new ObjectDataContract       ();
                case DataContractKind.QNameDataContract         : return new QNameDataContract        ();
                case DataContractKind.ShortDataContract         : return new ShortDataContract        ();
                case DataContractKind.SignedByteDataContract    : return new SignedByteDataContract   ();
                case DataContractKind.StringDataContract        : return new StringDataContract       ();
                case DataContractKind.TimeSpanDataContract      : return new TimeSpanDataContract     ();
                case DataContractKind.UnsignedByteDataContract  : return new UnsignedByteDataContract ();
                case DataContractKind.UnsignedIntDataContract   : return new UnsignedIntDataContract  ();
                case DataContractKind.UnsignedLongDataContract  : return new UnsignedLongDataContract ();
                case DataContractKind.UnsignedShortDataContract : return new UnsignedShortDataContract();
                case DataContractKind.UriDataContract           : return new UriDataContract          ();
                case DataContractKind.InvalidDataContract       : return new InvalidDataContract      ();
            }
            throw new Exception("unknown data contract kind");
        }

        static bool IsRemovedByDR(this Type type)
        {
            return (type == typeof(System.Runtime.CompilerServices.DependencyReductionTypeRemoved));
        }
    }
}
