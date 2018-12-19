# Description

Web hook API for receiving web hook notifications from Azure DevOps.

Received notifications are stored in a non-persistent repository that can 
be read via a REST API.

## Azure Hosting

Hosted on a free App Service in Azure.

Hostname: **devopswebhook.azurewebsites.net**

Read received build notifications:<br />
https://devopswebhook.azurewebsites.net/api/BuildNotifications/

## SignalR Hub

The web application pushes build notifications via SignalR using this endpoint:
https://devopswebhook.azurewebsites.net/BuildNotificationHub

#### Azure DevOps Web Hook JSON

Azure build notification web hook endpoint URL:<br />
https://devopswebhook.azurewebsites.net/api/webhook/vsts

See: https://docs.microsoft.com/en-us/azure/devops/service-hooks/services/webhooks?view=vsts <br />
for info on how to configure service hooks in Azure DevOps.

Example JSON POST data from a Azure DevOps *build complete* web hook notification:

```json
{
    "subscriptionId": "00000000-0000-0000-0000-000000000000",
    "notificationId": 4,
    "id": "4a5d99d6-1c75-4e53-91b9-ee80057d4ce3",
    "eventType": "build.complete",
    "publisherId": "tfs",
    "message": null,
    "detailedMessage": null,
    "resource": {
        "id": 2,
        "url": "https://fabrikam-fiber-inc.visualstudio.com/DefaultCollection/71777fbc-1cf2-4bd1-9540-128c1c71f766/_apis/build/Builds/2"
    },
    "resourceVersion": "1.0",
    "resourceContainers": {
        "collection": {
            "id": "c12d0eb8-e382-443b-9f9c-c52cba5014c2"
        },
        "account": {
            "id": "f844ec47-a9db-4511-8281-8b63f4eaf94e"
        },
        "project": {
            "id": "be9b3917-87e6-42a4-a549-2bc06a7a878f"
        }
    },
    "createdDate": "2018-12-15T14:21:58.090198Z"
}
```

