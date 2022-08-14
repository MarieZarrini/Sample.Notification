using sample.notification;

var phoneNumbers = new string[] { "091111", "09222", "09333", "09444", "095555" };
var message = "sample message";

var providerService= new ProviderService();
providerService.SendMessage(phoneNumbers, message);