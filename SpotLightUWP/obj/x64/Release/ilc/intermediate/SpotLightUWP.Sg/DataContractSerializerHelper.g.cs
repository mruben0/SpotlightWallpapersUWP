using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Xml;

[assembly: global::System.Reflection.AssemblyVersion("4.0.0.0")]



namespace System.Runtime.Serialization.Generated
{
    [global::System.Runtime.CompilerServices.__BlockReflection]
    public static partial class DataContractSerializerHelper
    {
        static void InitDataContracts()
        {
            global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Runtime.Serialization.DataContract> dataContracts = global::System.Runtime.Serialization.DataContract.GetDataContracts();
            PopulateContractDictionary(dataContracts);
            global::System.Collections.Generic.Dictionary<global::System.Runtime.Serialization.DataContract, global::System.Runtime.Serialization.Json.JsonReadWriteDelegates> jsonDelegates = global::System.Runtime.Serialization.Json.JsonReadWriteDelegates.GetJsonDelegates();
            PopulateJsonDelegateDictionary(
                                dataContracts, 
                                jsonDelegates
                            );
        }
        static int[] s_knownContractsLists = new int[] {
              -1, }
        ;
        // Count = 307
        static int[] s_xmlDictionaryStrings = new int[] {
                0, // array length: 0
                8, // array length: 8
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                8, // array length: 8
                913, // index: 913, string: "home_oid"
                922, // index: 922, string: "iss"
                926, // index: 926, string: "name"
                931, // index: 931, string: "oid"
                935, // index: 935, string: "preferred_username"
                954, // index: 954, string: "sub"
                958, // index: 958, string: "tid"
                962, // index: 962, string: "ver"
                8, // array length: 8
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                10, // array length: 10
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                10, // array length: 10
                966, // index: 966, string: "client_id"
                976, // index: 976, string: "client_info"
                962, // index: 962, string: "ver"
                988, // index: 988, string: "access_token"
                1001, // index: 1001, string: "authority"
                1011, // index: 1011, string: "expires_on"
                1022, // index: 1022, string: "id_token"
                1031, // index: 1031, string: "scope"
                1037, // index: 1037, string: "token_type"
                1048, // index: 1048, string: "user_assertion_hash"
                10, // array length: 10
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                3, // array length: 3
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                3, // array length: 3
                966, // index: 966, string: "client_id"
                976, // index: 976, string: "client_info"
                962, // index: 962, string: "ver"
                3, // array length: 3
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                8, // array length: 8
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                8, // array length: 8
                966, // index: 966, string: "client_id"
                976, // index: 976, string: "client_info"
                962, // index: 962, string: "ver"
                1068, // index: 1068, string: "displayable_id"
                1083, // index: 1083, string: "environment"
                1095, // index: 1095, string: "identity_provider"
                926, // index: 926, string: "name"
                1113, // index: 1113, string: "refresh_token"
                8, // array length: 8
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                359, // index: 359, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                2, // array length: 2
                1127, // index: 1127, string: "uid"
                1131, // index: 1131, string: "utid"
                2, // array length: 2
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                263, // index: 263, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal"
                12, // array length: 12
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                12, // array length: 12
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                988, // index: 988, string: "access_token"
                976, // index: 976, string: "client_info"
                1194, // index: 1194, string: "expires_in"
                1022, // index: 1022, string: "id_token"
                1113, // index: 1113, string: "refresh_token"
                1031, // index: 1031, string: "scope"
                1037, // index: 1037, string: "token_type"
                12, // array length: 12
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                5, // array length: 5
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                1, // array length: 1
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                5, // array length: 5
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                5, // array length: 5
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                7, // array length: 7
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                7, // array length: 7
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                798, // index: 798, string: "links"
                1205, // index: 1205, string: "subject"
                7, // array length: 7
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                2, // array length: 2
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                2, // array length: 2
                1213, // index: 1213, string: "href"
                1218, // index: 1218, string: "rel"
                2, // array length: 2
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                8, // array length: 8
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                8, // array length: 8
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                1222, // index: 1222, string: "authorization_endpoint"
                1245, // index: 1245, string: "issuer"
                1252, // index: 1252, string: "token_endpoint"
                8, // array length: 8
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                6, // array length: 6
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                6, // array length: 6
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                1267, // index: 1267, string: "tenant_discovery_endpoint"
                6, // array length: 6
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                6, // array length: 6
                -1, // string: null
                -1, // string: null
                -1, // string: null
                621, // index: 621, string: "http://schemas.microsoft.com/2003/10/Serialization/Arrays"
                -1, // string: null
                -1, // string: null
                2, // array length: 2
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                6, // array length: 6
                1136, // index: 1136, string: "claims"
                1143, // index: 1143, string: "correlation_id"
                1158, // index: 1158, string: "error"
                1164, // index: 1164, string: "error_codes"
                1176, // index: 1176, string: "error_description"
                874, // index: 874, string: "IdentityProviderService"
                6, // array length: 6
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                506, // index: 506, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2"
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                1, // array length: 1
                -1, // string: null
                1, // array length: 1
                701, // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
                1, // array length: 1
                1293, // index: 1293, string: "PassiveAuthEndpoint"
                1, // array length: 1
                701  // index: 701, string: "http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance"
        };
        // Count = 0
        static global::MemberEntry[] s_dataMemberLists = new global::MemberEntry[0];
        static readonly byte[] s_dataContractMap_Hashtable = null;
        // Count=53
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractMapEntry[] s_dataContractMap = new global::DataContractMapEntry[] {
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 16, // 0x10
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 160, // 0xa0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Private.Xml, Version=4.0.1.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd" +
                                "51")),
                    TableIndex = 176, // 0xb0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 224, // 0xe0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 320, // 0x140
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.IdToken, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicK" +
                                "eyToken=0a613f4dd989e8ae")),
                    TableIndex = 1, // 0x1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.AccessTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cultu" +
                                "re=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 17, // 0x11
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.BaseTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Culture" +
                                "=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 33, // 0x21
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.RefreshTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cult" +
                                "ure=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 49, // 0x31
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.ClientInfo, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, Publ" +
                                "icKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 65, // 0x41
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.TokenResponse, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neu" +
                                "tral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 81, // 0x51
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.OAuth2ResponseBase, Microsoft.Identity.Client, Version=1.1.2.0, Cultur" +
                                "e=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 97, // 0x61
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 2, // 0x2
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.AdfsWebFingerResponse, Microsoft.Identity.Client, Version=1.1.2.0, C" +
                                "ulture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 113, // 0x71
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 18, // 0x12
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutr" +
                                "al, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 129, // 0x81
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.TenantDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2.0," +
                                " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 145, // 0x91
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.InstanceDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2." +
                                "0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 161, // 0xa1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.DrsMetadataResponse, Microsoft.Identity.Client, Version=1.1.2.0, Cul" +
                                "ture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 177, // 0xb1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.IdentityProviderService, Microsoft.Identity.Client, Version=1.1.2.0," +
                                " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    TableIndex = 193, // 0xc1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 34, // 0x22
                }
        };
        static readonly byte[] s_dataContracts_Hashtable = null;
        // Count=21
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractEntry[] s_dataContracts = new global::DataContractEntry[] {
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 0, // boolean
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 0, // boolean
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 0, // boolean
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.BooleanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 93, // base64Binary
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 93, // base64Binary
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 93, // base64Binary
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ByteArrayDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 106, // char
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 106, // char
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 106, // char
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.CharDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 111, // dateTime
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 111, // dateTime
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 111, // dateTime
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DateTimeDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 120, // decimal
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 120, // decimal
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 120, // decimal
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DecimalDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 128, // double
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 128, // double
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 128, // double
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DoubleDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 135, // float
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 135, // float
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 135, // float
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.FloatDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 141, // guid
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 141, // guid
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 141, // guid
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.GuidDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 146, // int
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 146, // int
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 146, // int
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.IntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 150, // long
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 150, // long
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 150, // long
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.LongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 155, // anyType
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 155, // anyType
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 155, // anyType
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.ObjectDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 163, // QName
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 163, // QName
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 163, // QName
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Private.Xml, Version=4.0.1.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd" +
                                    "51")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Private.Xml, Version=4.0.1.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd" +
                                    "51")),
                    },
                    Kind = global::DataContractKind.QNameDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 169, // short
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 169, // short
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 169, // short
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 175, // byte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 175, // byte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 175, // byte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.SignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 180, // string
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 180, // string
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 180, // string
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.StringDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 187, // duration
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 187, // duration
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 187, // duration
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.TimeSpanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 196, // unsignedByte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 196, // unsignedByte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 196, // unsignedByte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 209, // unsignedInt
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 209, // unsignedInt
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 209, // unsignedInt
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedIntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 221, // unsignedLong
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 221, // unsignedLong
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 221, // unsignedLong
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedLongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 234, // unsignedShort
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 234, // unsignedShort
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 234, // unsignedShort
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 248, // anyURI
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 248, // anyURI
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 248, // anyURI
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.UriDataContract,
                }
        };
        static readonly byte[] s_classDataContracts_Hashtable = null;
        // Count=13
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::ClassDataContractEntry[] s_classDataContracts = new global::ClassDataContractEntry[] {
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 255, // IdToken
                        NamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        StableNameIndex = 255, // IdToken
                        StableNameNamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        TopLevelElementNameIndex = 255, // IdToken
                        TopLevelElementNamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.IdToken, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicK" +
                                    "eyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.IdToken, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicK" +
                                    "eyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 1,
                    ContractNamespacesListIndex = 10,
                    MemberNamesListIndex = 12,
                    MemberNamespacesListIndex = 21,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 338, // AccessTokenCacheItem
                        NamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        StableNameIndex = 338, // AccessTokenCacheItem
                        StableNameNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        TopLevelElementNameIndex = 338, // AccessTokenCacheItem
                        TopLevelElementNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.AccessTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cultu" +
                                    "re=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.AccessTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cultu" +
                                    "re=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 30,
                    ContractNamespacesListIndex = 41,
                    MemberNamesListIndex = 44,
                    MemberNamespacesListIndex = 55,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 440, // BaseTokenCacheItem
                        NamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        StableNameIndex = 440, // BaseTokenCacheItem
                        StableNameNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        TopLevelElementNameIndex = 440, // BaseTokenCacheItem
                        TopLevelElementNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.BaseTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Culture" +
                                    "=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.BaseTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Culture" +
                                    "=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 66,
                    ContractNamespacesListIndex = 70,
                    MemberNamesListIndex = 72,
                    MemberNamespacesListIndex = 76,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 459, // RefreshTokenCacheItem
                        NamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        StableNameIndex = 459, // RefreshTokenCacheItem
                        StableNameNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        TopLevelElementNameIndex = 459, // RefreshTokenCacheItem
                        TopLevelElementNamespaceIndex = 359, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Cache
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.RefreshTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cult" +
                                    "ure=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Cache.RefreshTokenCacheItem, Microsoft.Identity.Client, Version=1.1.2.0, Cult" +
                                    "ure=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 80,
                    ContractNamespacesListIndex = 89,
                    MemberNamesListIndex = 92,
                    MemberNamespacesListIndex = 101,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 481, // ClientInfo
                        NamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        StableNameIndex = 481, // ClientInfo
                        StableNameNamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        TopLevelElementNameIndex = 481, // ClientInfo
                        TopLevelElementNamespaceIndex = 263, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.ClientInfo, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, Publ" +
                                    "icKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.ClientInfo, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, Publ" +
                                    "icKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 110,
                    ContractNamespacesListIndex = 113,
                    MemberNamesListIndex = 115,
                    MemberNamespacesListIndex = 118,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 492, // TokenResponse
                        NamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        StableNameIndex = 492, // TokenResponse
                        StableNameNamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        TopLevelElementNameIndex = 492, // TokenResponse
                        TopLevelElementNamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.TokenResponse, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neu" +
                                    "tral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.TokenResponse, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neu" +
                                    "tral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 121,
                    ContractNamespacesListIndex = 134,
                    MemberNamesListIndex = 137,
                    MemberNamespacesListIndex = 150,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 588, // OAuth2ResponseBase
                        NamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        StableNameIndex = 588, // OAuth2ResponseBase
                        StableNameNamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        TopLevelElementNameIndex = 588, // OAuth2ResponseBase
                        TopLevelElementNamespaceIndex = 506, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.OAuth2
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.OAuth2ResponseBase, Microsoft.Identity.Client, Version=1.1.2.0, Cultur" +
                                    "e=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.OAuth2.OAuth2ResponseBase, Microsoft.Identity.Client, Version=1.1.2.0, Cultur" +
                                    "e=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 163,
                    ContractNamespacesListIndex = 169,
                    MemberNamesListIndex = 171,
                    MemberNamespacesListIndex = 177,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 679, // AdfsWebFingerResponse
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 679, // AdfsWebFingerResponse
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 679, // AdfsWebFingerResponse
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.AdfsWebFingerResponse, Microsoft.Identity.Client, Version=1.1.2.0, C" +
                                    "ulture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.AdfsWebFingerResponse, Microsoft.Identity.Client, Version=1.1.2.0, C" +
                                    "ulture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 183,
                    ContractNamespacesListIndex = 191,
                    MemberNamesListIndex = 194,
                    MemberNamespacesListIndex = 202,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 798, // links
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 798, // links
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 798, // links
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutr" +
                                    "al, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutr" +
                                    "al, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 210,
                    ContractNamespacesListIndex = 213,
                    MemberNamesListIndex = 215,
                    MemberNamespacesListIndex = 218,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 804, // TenantDiscoveryResponse
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 804, // TenantDiscoveryResponse
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 804, // TenantDiscoveryResponse
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.TenantDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2.0," +
                                    " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.TenantDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2.0," +
                                    " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 221,
                    ContractNamespacesListIndex = 230,
                    MemberNamesListIndex = 233,
                    MemberNamespacesListIndex = 242,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 828, // InstanceDiscoveryResponse
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 828, // InstanceDiscoveryResponse
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 828, // InstanceDiscoveryResponse
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.InstanceDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2." +
                                    "0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.InstanceDiscoveryResponse, Microsoft.Identity.Client, Version=1.1.2." +
                                    "0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 251,
                    ContractNamespacesListIndex = 258,
                    MemberNamesListIndex = 261,
                    MemberNamespacesListIndex = 268,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 854, // DrsMetadataResponse
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 854, // DrsMetadataResponse
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 854, // DrsMetadataResponse
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.DrsMetadataResponse, Microsoft.Identity.Client, Version=1.1.2.0, Cul" +
                                    "ture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.DrsMetadataResponse, Microsoft.Identity.Client, Version=1.1.2.0, Cul" +
                                    "ture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 275,
                    ContractNamespacesListIndex = 282,
                    MemberNamesListIndex = 285,
                    MemberNamespacesListIndex = 292,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 874, // IdentityProviderService
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 874, // IdentityProviderService
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 874, // IdentityProviderService
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.IdentityProviderService, Microsoft.Identity.Client, Version=1.1.2.0," +
                                    " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.IdentityProviderService, Microsoft.Identity.Client, Version=1.1.2.0," +
                                    " Culture=neutral, PublicKeyToken=0a613f4dd989e8ae")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 299,
                    ContractNamespacesListIndex = 301,
                    MemberNamesListIndex = 303,
                    MemberNamespacesListIndex = 305,
                }
        };
        static readonly byte[] s_collectionDataContracts_Hashtable = null;
        // Count=3
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::CollectionDataContractEntry[] s_collectionDataContracts = new global::CollectionDataContractEntry[] {
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 607, // ArrayOfstring
                        NamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 607, // ArrayOfstring
                        StableNameNamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 607, // ArrayOfstring
                        TopLevelElementNamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    CollectionItemNameIndex = 180, // string
                    KeyNameIndex = -1,
                    ItemNameIndex = 180, // string
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.Array,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 785, // ArrayOflinks
                        NamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        StableNameIndex = 785, // ArrayOflinks
                        StableNameNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        TopLevelElementNameIndex = 785, // ArrayOflinks
                        TopLevelElementNamespaceIndex = 701, // http://schemas.datacontract.org/2004/07/Microsoft.Identity.Client.Internal.Instance
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf(@"System.Collections.Generic.List`1[[Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutral, PublicKeyToken=0a613f4dd989e8ae]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.1.1.0, Culture=neutral, PublicKeyToken=b03f5f7f" +
                                    "11d50a3a")),
                    },
                    CollectionItemNameIndex = 798, // links
                    KeyNameIndex = -1,
                    ItemNameIndex = 798, // links
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("Microsoft.Identity.Client.Internal.Instance.LinksList, Microsoft.Identity.Client, Version=1.1.2.0, Culture=neutr" +
                                "al, PublicKeyToken=0a613f4dd989e8ae")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 898, // ArrayOfanyType
                        NamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 898, // ArrayOfanyType
                        StableNameNamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 898, // ArrayOfanyType
                        TopLevelElementNamespaceIndex = 621, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    CollectionItemNameIndex = 155, // anyType
                    KeyNameIndex = -1,
                    ItemNameIndex = 155, // anyType
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.Array,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }
        };
        static readonly byte[] s_enumDataContracts_Hashtable = null;
        // Count=0
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::EnumDataContractEntry[] s_enumDataContracts = new global::EnumDataContractEntry[0];
        static readonly byte[] s_xmlDataContracts_Hashtable = null;
        // Count=0
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::XmlDataContractEntry[] s_xmlDataContracts = new global::XmlDataContractEntry[0];
        static readonly byte[] s_jsonDelegatesList_Hashtable = null;
        // Count=16
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::JsonDelegateEntry[] s_jsonDelegatesList = new global::JsonDelegateEntry[] {
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 37,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type3.WriteIdTokenToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type2.ReadIdTokenFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 38,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type7.WriteAccessTokenCacheItemToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type6.ReadAccessTokenCacheItemFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 39,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type11.WriteBaseTokenCacheItemToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type10.ReadBaseTokenCacheItemFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 40,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type15.WriteRefreshTokenCacheItemToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type14.ReadRefreshTokenCacheItemFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 41,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type19.WriteClientInfoToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type18.ReadClientInfoFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 42,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type23.WriteTokenResponseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type22.ReadTokenResponseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 43,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type27.WriteOAuth2ResponseBaseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type26.ReadOAuth2ResponseBaseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 44,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type32.WriteArrayOfstringToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type31.ReadArrayOfstringFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type33.ReadArrayOfstringFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 45,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type37.WriteAdfsWebFingerResponseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type36.ReadAdfsWebFingerResponseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 46,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type42.WriteArrayOflinksToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type41.ReadArrayOflinksFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type43.ReadArrayOflinksFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 47,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type47.WritelinksToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type46.ReadlinksFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 48,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type51.WriteTenantDiscoveryResponseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type50.ReadTenantDiscoveryResponseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 49,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type55.WriteInstanceDiscoveryResponseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type54.ReadInstanceDiscoveryResponseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 50,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type59.WriteDrsMetadataResponseToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type58.ReadDrsMetadataResponseFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 51,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type63.WriteIdentityProviderServiceToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type62.ReadIdentityProviderServiceFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 52,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type68.WriteArrayOfanyTypeToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type67.ReadArrayOfanyTypeFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type69.ReadArrayOfanyTypeFromJsonIsGetOnly),
                }
        };
        static char[] s_stringPool = new char[] {
            'b','o','o','l','e','a','n','\0','h','t','t','p',':','/','/','w','w','w','.','w','3','.','o','r','g','/','2','0','0','1',
            '/','X','M','L','S','c','h','e','m','a','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','m','i','c','r',
            'o','s','o','f','t','.','c','o','m','/','2','0','0','3','/','1','0','/','S','e','r','i','a','l','i','z','a','t','i','o',
            'n','/','\0','b','a','s','e','6','4','B','i','n','a','r','y','\0','c','h','a','r','\0','d','a','t','e','T','i','m','e','\0',
            'd','e','c','i','m','a','l','\0','d','o','u','b','l','e','\0','f','l','o','a','t','\0','g','u','i','d','\0','i','n','t','\0',
            'l','o','n','g','\0','a','n','y','T','y','p','e','\0','Q','N','a','m','e','\0','s','h','o','r','t','\0','b','y','t','e','\0',
            's','t','r','i','n','g','\0','d','u','r','a','t','i','o','n','\0','u','n','s','i','g','n','e','d','B','y','t','e','\0','u',
            'n','s','i','g','n','e','d','I','n','t','\0','u','n','s','i','g','n','e','d','L','o','n','g','\0','u','n','s','i','g','n',
            'e','d','S','h','o','r','t','\0','a','n','y','U','R','I','\0','I','d','T','o','k','e','n','\0','h','t','t','p',':','/','/',
            's','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r','g','/','2','0','0','4','/',
            '0','7','/','M','i','c','r','o','s','o','f','t','.','I','d','e','n','t','i','t','y','.','C','l','i','e','n','t','.','I',
            'n','t','e','r','n','a','l','\0','A','c','c','e','s','s','T','o','k','e','n','C','a','c','h','e','I','t','e','m','\0','h',
            't','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r','g',
            '/','2','0','0','4','/','0','7','/','M','i','c','r','o','s','o','f','t','.','I','d','e','n','t','i','t','y','.','C','l',
            'i','e','n','t','.','I','n','t','e','r','n','a','l','.','C','a','c','h','e','\0','B','a','s','e','T','o','k','e','n','C',
            'a','c','h','e','I','t','e','m','\0','R','e','f','r','e','s','h','T','o','k','e','n','C','a','c','h','e','I','t','e','m',
            '\0','C','l','i','e','n','t','I','n','f','o','\0','T','o','k','e','n','R','e','s','p','o','n','s','e','\0','h','t','t','p',
            ':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r','g','/','2','0',
            '0','4','/','0','7','/','M','i','c','r','o','s','o','f','t','.','I','d','e','n','t','i','t','y','.','C','l','i','e','n',
            't','.','I','n','t','e','r','n','a','l','.','O','A','u','t','h','2','\0','O','A','u','t','h','2','R','e','s','p','o','n',
            's','e','B','a','s','e','\0','A','r','r','a','y','O','f','s','t','r','i','n','g','\0','h','t','t','p',':','/','/','s','c',
            'h','e','m','a','s','.','m','i','c','r','o','s','o','f','t','.','c','o','m','/','2','0','0','3','/','1','0','/','S','e',
            'r','i','a','l','i','z','a','t','i','o','n','/','A','r','r','a','y','s','\0','A','d','f','s','W','e','b','F','i','n','g',
            'e','r','R','e','s','p','o','n','s','e','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a',
            'c','o','n','t','r','a','c','t','.','o','r','g','/','2','0','0','4','/','0','7','/','M','i','c','r','o','s','o','f','t',
            '.','I','d','e','n','t','i','t','y','.','C','l','i','e','n','t','.','I','n','t','e','r','n','a','l','.','I','n','s','t',
            'a','n','c','e','\0','A','r','r','a','y','O','f','l','i','n','k','s','\0','l','i','n','k','s','\0','T','e','n','a','n','t',
            'D','i','s','c','o','v','e','r','y','R','e','s','p','o','n','s','e','\0','I','n','s','t','a','n','c','e','D','i','s','c',
            'o','v','e','r','y','R','e','s','p','o','n','s','e','\0','D','r','s','M','e','t','a','d','a','t','a','R','e','s','p','o',
            'n','s','e','\0','I','d','e','n','t','i','t','y','P','r','o','v','i','d','e','r','S','e','r','v','i','c','e','\0','A','r',
            'r','a','y','O','f','a','n','y','T','y','p','e','\0','h','o','m','e','_','o','i','d','\0','i','s','s','\0','n','a','m','e',
            '\0','o','i','d','\0','p','r','e','f','e','r','r','e','d','_','u','s','e','r','n','a','m','e','\0','s','u','b','\0','t','i',
            'd','\0','v','e','r','\0','c','l','i','e','n','t','_','i','d','\0','c','l','i','e','n','t','_','i','n','f','o','\0','a','c',
            'c','e','s','s','_','t','o','k','e','n','\0','a','u','t','h','o','r','i','t','y','\0','e','x','p','i','r','e','s','_','o',
            'n','\0','i','d','_','t','o','k','e','n','\0','s','c','o','p','e','\0','t','o','k','e','n','_','t','y','p','e','\0','u','s',
            'e','r','_','a','s','s','e','r','t','i','o','n','_','h','a','s','h','\0','d','i','s','p','l','a','y','a','b','l','e','_',
            'i','d','\0','e','n','v','i','r','o','n','m','e','n','t','\0','i','d','e','n','t','i','t','y','_','p','r','o','v','i','d',
            'e','r','\0','r','e','f','r','e','s','h','_','t','o','k','e','n','\0','u','i','d','\0','u','t','i','d','\0','c','l','a','i',
            'm','s','\0','c','o','r','r','e','l','a','t','i','o','n','_','i','d','\0','e','r','r','o','r','\0','e','r','r','o','r','_',
            'c','o','d','e','s','\0','e','r','r','o','r','_','d','e','s','c','r','i','p','t','i','o','n','\0','e','x','p','i','r','e',
            's','_','i','n','\0','s','u','b','j','e','c','t','\0','h','r','e','f','\0','r','e','l','\0','a','u','t','h','o','r','i','z',
            'a','t','i','o','n','_','e','n','d','p','o','i','n','t','\0','i','s','s','u','e','r','\0','t','o','k','e','n','_','e','n',
            'd','p','o','i','n','t','\0','t','e','n','a','n','t','_','d','i','s','c','o','v','e','r','y','_','e','n','d','p','o','i',
            'n','t','\0','P','a','s','s','i','v','e','A','u','t','h','E','n','d','p','o','i','n','t','\0'};
    }
}
