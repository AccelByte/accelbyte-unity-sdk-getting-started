﻿// Copyright (c) 2018 - 2019 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Collections.Generic;
using System.Net;
using AccelByte.Models;
using AccelByte.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace AccelByte.Api
{
    internal class TelemetryApi
    {
        private readonly string baseUrl;
        private readonly uint agentType;
        private readonly string deviceId;

        public TelemetryApi(string baseUrl)
        {
            this.baseUrl = baseUrl;

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsPlayer:
                    this.agentType = 70;
                    break;
                case RuntimePlatform.OSXPlayer:
                    this.agentType = 80;
                    break;
                case RuntimePlatform.LinuxPlayer:
                    this.agentType = 90;
                    break;
                case RuntimePlatform.Android:
                    this.agentType = 110;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    this.agentType = 120;
                    break;
                case RuntimePlatform.XboxOne:
                    this.agentType = 130;
                    break;
                case RuntimePlatform.PS4:
                    this.agentType = 140;
                    break;
                case RuntimePlatform.Switch:
                    this.agentType = 170;
                    break;
                case RuntimePlatform.tvOS:
                    this.agentType = 200;
                    break;
                case RuntimePlatform.WSAPlayerX86:
                    this.agentType = 210;
                    break;
                case RuntimePlatform.WSAPlayerX64:
                    this.agentType = 211;
                    break;
                case RuntimePlatform.WSAPlayerARM:
                    this.agentType = 212;
                    break;
                case RuntimePlatform.WebGLPlayer:
                    this.agentType = 220;
                    break;
            }

            this.deviceId = DeviceProvider.GetFromSystemInfo().DeviceId;
        }

        public IEnumerator<ITask> SendEvent<T>(string @namespace, string clientId, string userID,
            TelemetryEventTag eventTag, T eventData, ResultCallback callback)
        where T : class
        {
            Assert.IsTrue(typeof(T).IsSerializable,
                "Event data of type " + typeof(T) + " is not serializable. Try add [Serializable] attribute.");

            string nowTime = DateTime.UtcNow.ToString("O");
            string strEventData;

            if (eventData is string)
            {
                strEventData = "\"" + eventData + "\"";
            }
            else
            {
                strEventData = SimpleJson.SimpleJson.SerializeObject(eventData);
            }

            string jsonString = string.Format(
                "{{" +
                "\"AgentType\": {0}," +
                "\"AppID\": {1}," +
                "\"ClientID\": \"{2}\"," +
                "\"Data\": {3}," +
                "\"DeviceID\": \"{4}\"," +
                "\"EventID\": {5}," +
                "\"EventLevel\": {6}," +
                "\"EventTime\": \"{7}\"," +
                "\"EventType\": {8}," +
                "\"UUID\": \"{9:N}\"," +
                "\"UX\": {10}," +
                "\"UserID\": \"{11}\"" +
                "}}", this.agentType,
                eventTag.AppId,
                clientId,
                strEventData,
                this.deviceId,
                eventTag.Id,
                eventTag.Level,
                nowTime,
                eventTag.Type,
                Guid.NewGuid(),
                eventTag.UX,
                userID);

            var request = HttpRequestBuilder
                .CreatePost(this.baseUrl +
                            "/telemetry/public/namespaces/{namespace}/events/gameclient/{appID}/{eventType}/{eventLevel}/{eventID}")
                .WithPathParam("namespace", @namespace)
                .WithPathParam("appID", eventTag.AppId.ToString())
                .WithPathParam("eventType", eventTag.Type.ToString())
                .WithPathParam("eventLevel", eventTag.Level.ToString())
                .WithPathParam("eventID", eventTag.Id.ToString())
                .WithContentType(MediaType.ApplicationJson)
                .WithBody(jsonString)
                .ToRequest();

            HttpWebResponse response = null;

            yield return Task.Await(request, rsp => response = rsp);

            if (response == null)
            {
                callback.Try(Result.CreateError(ErrorCode.NetworkError, "There is no response"));
                yield break;
            }

            response.Close();
            Result result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NoContent:
                    result = Result.CreateOk();
                    break;
                default:
                    result = Result.CreateError((ErrorCode) response.StatusCode, "Sending telemetry event failed");
                    break;
            }

            callback.Try(result);
        }
    }
}