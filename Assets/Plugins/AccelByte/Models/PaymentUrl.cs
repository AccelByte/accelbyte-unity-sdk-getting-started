// Copyright (c) 2018 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;

namespace AccelByte.Models
{
    [DataContract]
    public class PaymentUrl
    {
        [DataMember] public string paymentProvider { get; set; } //['XSOLLA', 'WALLET'],
        [DataMember] public string paymentUrl { get; set; }
        [DataMember] public string paymentToken { get; set; }
        [DataMember] public string returnUrl { get; set; }
        [DataMember] public string paymentType { get; set; } //['QR_CODE', 'LINK']
    }
}