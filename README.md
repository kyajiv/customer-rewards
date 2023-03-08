# Customer Rewards
Sample web api and container based application using .NET 7.


# Tools and IDE
This project is built using Visual Studio 2022 and .NET 7. To run this project locally, use Visual Studio 2022 or later. This project also supports containers and to run in container, use docker desktop. To open the project solution, check out the code and open file Customer.Rewards.Api/Customer.Rewards.Api.sln using Visual Studio.


# Docker Support

To build the Docker image and run the container inside docker Linux instance, do the following:
Open command line and navigate to folder containing solution file Customer.Rewards.Api.sln.

To create the Docker image, run the following command.

docker build -t customerrewardsimage -f Customer.Rewards.Api\Dockerfile .

To view all the Docker images, run the following command.

docker images

To create and run the container, run the following command.

docker run -ti --rm -p 8080:80 --name customerrewardsimagecontainer customerrewardsimage

Open url in browser http://localhost:8080/swagger/index.html 


# API Documentation
API documentation of request/response using swagger is available at {Scheme}://{ServiceHost}:{ServicePort}/swagger

![image](https://user-images.githubusercontent.com/20542279/223698915-10b1a9b8-3707-4962-9261-cd9d2af70ed5.png)


# Health Check Endpoint
Health check endpoint can be used to monitor the service health. Health check endpoint {Scheme}://{ServiceHost}:{ServicePort}/health-check 


# Dataset 
Following transaction data set is used which is under Resources/TransactionHistory.json

![image](https://user-images.githubusercontent.com/20542279/223702803-21ccbff2-03c7-4431-9cfb-a0ca9bbc4808.png)


# Test Client
 To test this api, we can use any client like postman or Swagger UI. 
 
![image](https://user-images.githubusercontent.com/20542279/223704391-95044aeb-26a0-43a8-b381-2ecf64527352.png)


# Unit Tests
Unit tests are added under project Customer.Rewards.Api.Tests. We are using Xunit as testing framework and Moq as mocking framework. 
To run tests, go to Menu item Test -> Run All Tests




