# Test Task

## Project Overview

The test task is designed to conduct experiments with token devices, store them, and display statistics.
## Table of Contents
1.	[API Endpoints](https://github.com/51xel/Task_1#api-endpoints)
2.	[Experiments](https://github.com/51xel/Task_1#experiments)
3.	[Requirements and Restrictions](https://github.com/51xel/Task_1#requirements-and-restrictions)
4.	[Technologies Used](https://github.com/51xel/Task_1#technologies-used)
5.	[Database Structure](https://github.com/51xel/Task_1#database-structure)
    
## API Endpoints
### 1. Generate Client ID and Request Experiment
   
•	Endpoint: /experiment/{experiment-name}

•	HTTP Method: GET

•	Parameters:

  •	device-token: Unique device token

•	Response:

  •	key: Name of the experiment (e.g., "button_color" or "price")
  
  •	value: The assigned value for the experiment (e.g., "#FF0000" or "10")
  
### 2. Statistics Page 
   
  •	Create a JSON format data experiment statistics, including the total number of devices participating and their distribution among the options.
   
## Experiments

### 1. Button Color Experiment
   
  •	Key: button_color

  •	Options:
  
    #FF0000 (33.3%)
    
    #00FF00 (33.3%)
    
    #0000FF (33.3%)
    
### 2. Price Experiment

  •	Key: price
  
  •	Options:
  
    10 (75%)
    
    20 (10%)
    
    50 (5%)
    
    5 (10%)
    
## Requirements and Restrictions

1.	Once a device receives a value for an experiment, it will always receive that value.
   
2.	Experiments are only performed for new devices, and devices should not know about experiments created after their first request.

## Technologies Used

•	ASP.NET Core Web API

•	MySQL

•	ADO.NET Entity Framework

## Database Structure

![alt text](https://i.imgur.com/JIP5lHM.png)
