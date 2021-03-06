using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {


        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_Int32_Binding.Register(app);
            LitJson_JsonMapper_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            System_Diagnostics_Stopwatch_Binding.Register(app);
            UnityEngine_Vector3_Binding.Register(app);
            System_String_Binding.Register(app);
            System_Boolean_Binding.Register(app);
            System_Object_Binding.Register(app);
            UnityEngine_Quaternion_Binding.Register(app);
            UnityEngine_Vector2_Binding.Register(app);
            UnityEngine_Time_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            CoroutineDemo_Binding.Register(app);
            UnityEngine_WaitForSeconds_Binding.Register(app);
            System_NotSupportedException_Binding.Register(app);
            CLRBindingTestClass_Binding.Register(app);
            TestClassBase_Binding.Register(app);
            DelegateDemo_Binding.Register(app);
            MyDelegateDemo_Binding.Register(app);
            System_Int32_Binding.Register(app);
            BombFramework_AccPwdRequet_Binding.Register(app);
            Google_Protobuf_MessageParser_1_AccPwdRequet_Binding.Register(app);
            SequentialFSM_SequentialFSMControl_Binding.Register(app);
            UnityEngine_Application_Binding.Register(app);
            UnityEngine_AssetBundle_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            UnityEngine_Transform_Binding.Register(app);
            BombServer_Kernel_KeyObjectMap_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            UnityEngine_Resources_Binding.Register(app);
            BombServer_Kernel_SystemEvent_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_ILTypeInstance_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            System_Exception_Binding.Register(app);
            System_Type_Binding.Register(app);
            System_Activator_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
        }
    }
}
