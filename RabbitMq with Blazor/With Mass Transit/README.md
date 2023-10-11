To boot up docker image with broker
docker run -d -p 5672:5672 -p 15672:15672 --name some-rabbit rabbitmq:3-management

The masstransit docs recomment $ docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq
but I've not seen anything requiring that to be used 

Order of start up is important. Queues are created when consumers are booted up so make sure to boot up the consumers before the producers.
https://stackoverflow.com/questions/70421240/masstransit-ensure-queues-created-before-publishing-messages#:~:text=The%20simple%20answer%2C%20start%20your%20consumer%20services%20before,the%20consumer%20service%20with%20all%20of%20its%20configuration.

Really important that the namespaces are the same for the contracts consumer and publisher otherwise queues won't match

name of consumer based on the name of the consumer file i.e. if you want to use GetStarted as the contract you need a GetStartedConsumer so that the correct queue name is created

- namespace is important
- base classes not suported