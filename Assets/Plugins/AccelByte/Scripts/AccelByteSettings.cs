// Copyright (c) 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

namespace AccelByte.Api
{
    using System.Collections.Generic;
    using UnityEngine;

#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoad]
#endif
    public sealed class AccelByteSettings : ScriptableObject
    {
        public static string PublisherNamespace
        {
            get { return Instance.config.PublisherNamespace; }
            set { Instance.config.PublisherNamespace = value; }
        }

        public static string Namespace
        {
            get { return Instance.config.Namespace; }
            set { Instance.config.Namespace = value; }
        }

        public static string BaseUrl
        {
            get { return Instance.config.BaseUrl; }
            set { Instance.config.BaseUrl = value; }
        }

        public static string IamServerUrl
        {
            get { return Instance.config.IamServerUrl; }
            set { Instance.config.IamServerUrl = value; }
        }

        public static string PlatformServerUrl
        {
            get { return Instance.config.PlatformServerUrl; }
            set { Instance.config.PlatformServerUrl = value; }
        }

        public static string BasicServerUrl
        {
            get { return Instance.config.BasicServerUrl; }
            set { Instance.config.BasicServerUrl = value; }
        }

        public static string LobbyServerUrl
        {
            get { return Instance.config.LobbyServerUrl; }
            set { Instance.config.LobbyServerUrl = value; }
        }

        public static string CloudStorageServerUrl
        {
            get { return Instance.config.CloudStorageServerUrl; }
            set { Instance.config.CloudStorageServerUrl = value; }
        }

        public static string TelemetryServerUrl
        {
            get { return Instance.config.TelemetryServerUrl; }
            set { Instance.config.TelemetryServerUrl = value; }
        }

        public static string WebLoginUrl
        {
            get { return Instance.config.WebLoginUrl; }
            set { Instance.config.WebLoginUrl = value; }
        }

        public static string ClientId
        {
            get { return Instance.config.ClientId; }
            set { Instance.config.ClientId = value; }
        }

        public static string ClientSecret
        {
            get { return Instance.config.ClientSecret; }
            set { Instance.config.ClientSecret = value; }
        }

        public static string RedirectUri
        {
            get { return Instance.config.RedirectUri; }
            set { Instance.config.RedirectUri = value; }
        }

        private Config config;

        private static AccelByteSettings instance;
        public static AccelByteSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<AccelByteSettings>("AccelByteSettings");

                    // This can happen if the developer never input their values into the Unity Editor
                    // and therefore never created the AccelByteSettings.asset file
                    // Use a dummy object with defaults for the getters so we don't have a null pointer exception
                    if (instance == null)
                    {
                        instance = CreateInstance<AccelByteSettings>();

#if UNITY_EDITOR
                        // Only in the editor should we save it to disk
                        string properPath = System.IO.Path.Combine(UnityEngine.Application.dataPath, "Resources");
                        if (!System.IO.Directory.Exists(properPath))
                        {
                          UnityEditor.AssetDatabase.CreateFolder("Assets", "Resources");
                        }

                        string fullPath = System.IO.Path.Combine(
                          System.IO.Path.Combine("Assets", "Resources"),
                          "AccelByteSettings.asset"
                        );
                        UnityEditor.AssetDatabase.CreateAsset(instance, fullPath);
#endif
                    }
                    Debug.Log("AccelByteSettings loaded");
                    instance.Load();
                }
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public Config CopyConfig()
        {
            return config.ShallowCopy();
        }

        /// <summary>
        ///  Load configuration from AccelByteSDKConfig.json
        /// </summary>
        public void Load()
        {
            var configFile = Resources.Load("AccelByteSDKConfig");
            if (configFile == null)
            {
                config = new Config();
            }
            else
            {
                string wholeJsonText = ((TextAsset)configFile).text;
                config = SimpleJson.SimpleJson.DeserializeObject<Config>(wholeJsonText);
            }
        }

        /// <summary>
        ///  Save configuration to AccelByteSDKConfig.json
        /// </summary>
        public void Save()
        {
            string jsonContent = SimpleJson.SimpleJson.SerializeObject(config);
            IDictionary<string, string> dict = config as IDictionary<string, string>;
            Debug.Log(dict);
#if UNITY_EDITOR
            // Only in the editor should we save it to disk
            string properPath = System.IO.Path.Combine(UnityEngine.Application.dataPath, "Resources");
            if (!System.IO.Directory.Exists(properPath))
            {
                UnityEditor.AssetDatabase.CreateFolder("Assets", "Resources");
            }

            string fullPath = System.IO.Path.Combine(
                System.IO.Path.Combine("Assets", "Resources"),
                "AccelByteSDKConfig.json"
            );

            System.IO.File.WriteAllText(fullPath, jsonContent);
#endif
        }
    }
}
