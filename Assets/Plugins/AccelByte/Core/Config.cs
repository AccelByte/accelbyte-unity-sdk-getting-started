// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace AccelByte.Api
{
    [DataContract]
    public class Config
    {
        [DataMember] public string BaseUrl { get; set; }
        [DataMember] public string PublisherNamespace { get; set; }
        [DataMember] public string Namespace { get; set; }
        [DataMember] public string IamServerUrl { get; set; }
        [DataMember] public string PlatformServerUrl { get; set; }
        [DataMember] public string BasicServerUrl { get; set; }
        [DataMember] public string LobbyServerUrl { get; set; }
        [DataMember] public string CloudStorageServerUrl { get; set; }
        [DataMember] public string TelemetryServerUrl { get; set; }
        [DataMember] public string GameProfileServerUrl { get; set; }
        [DataMember] public string WebLoginUrl { get; set; }
        [DataMember] public string ClientId { get; set; }
        [DataMember] public string ClientSecret { get; set; }
        [DataMember] public string RedirectUri { get; set; }

        /// <summary>
        ///  Copy member values
        /// </summary>
        public Config ShallowCopy()
        {
            return (Config)this.MemberwiseClone();
        }

        /// <summary>
        ///  Assign missing config values.
        /// </summary>
        public void Expand()
        {

            if (BaseUrl != null)
            {
                int index;
                // remove protocol 
                if ((index = BaseUrl.IndexOf("://")) > 0)
                {
                    BaseUrl = BaseUrl.Substring(index + 3);
                }

                string httpsBaseUrl = "https://" + BaseUrl;
                string wssBaseUrl = "wss://" + BaseUrl;

                if (IamServerUrl == null)
                {
                    IamServerUrl = httpsBaseUrl;
                }

                if (PlatformServerUrl == null)
                {
                    PlatformServerUrl = httpsBaseUrl;
                }

                if (BasicServerUrl == null)
                {
                    BasicServerUrl = httpsBaseUrl;
                }

                if (LobbyServerUrl == null)
                {
                    LobbyServerUrl = wssBaseUrl;
                }

                if (CloudStorageServerUrl == null)
                {
                    CloudStorageServerUrl = httpsBaseUrl;
                }

                if (TelemetryServerUrl == null)
                {
                    TelemetryServerUrl = httpsBaseUrl;
                }

                if (GameProfileServerUrl == null)
                {
                    GameProfileServerUrl = httpsBaseUrl;
                }
            }

            if (PublisherNamespace == null)
            {
                PublisherNamespace = Namespace;
            }
        }

        /// <summary>
        ///  Remove config values that can be derived from another value.
        /// </summary>
        public void Compact()
        {
            int index;
            // remove protocol
            if ((index = BaseUrl.IndexOf("://")) > 0)
            {
                BaseUrl = BaseUrl.Substring(index + 3);
            }

            if (BaseUrl != null)
            {
                string httpsBaseUrl = "https://" + BaseUrl;
                string wssBaseUrl = "wss://" + BaseUrl;

                if (IamServerUrl == httpsBaseUrl)
                {
                    IamServerUrl = null;
                }

                if (PlatformServerUrl == httpsBaseUrl)
                {
                    PlatformServerUrl = null;
                }

                if (BasicServerUrl == httpsBaseUrl)
                {
                    BasicServerUrl = null;
                }

                if (LobbyServerUrl == wssBaseUrl)
                {
                    LobbyServerUrl = null;
                }

                if (CloudStorageServerUrl == httpsBaseUrl)
                {
                    CloudStorageServerUrl = null;
                }

                if (TelemetryServerUrl == httpsBaseUrl)
                {
                    TelemetryServerUrl = null;
                }

                if (GameProfileServerUrl == httpsBaseUrl)
                {
                    GameProfileServerUrl = null;
                }
            }

            if (PublisherNamespace == Namespace)
            {
                PublisherNamespace = null;
            }
        }
    }
}