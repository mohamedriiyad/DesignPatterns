using DecoratorPattern;

var smsService = new ConcreteSMSService();
var notificationEmailService = new NotificationEmailDecorator();
notificationEmailService.SetService(smsService);
Console.WriteLine(notificationEmailService.SendSMS("6521", "0123456252", "Message content"));
