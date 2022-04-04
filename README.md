# DeliVeggie
The solution contains:

1.DeliVeggie.UI - An Angular application to display product list and product details.

2.DeliVeggie - A Web api with ProductController. The endpoints are available in Swagger

3.DeliVeggie.RabbitMQ - Publishes the requset from controller

4.DeliVeggie.Product.Service - A service that handles the requests published from DeliVeggie.RabbitMQ

5.DeliVeggie.MongoDB - Connects with mongoDB. 

                       At the first run uncomment the following to insert dummy data in collections :
                       a. _priceReduction.SeedInitialPriceDeductionData(); inside the constructor of PriceReductionRepository and
                       b._product.SeedInitialData(); inside the constructor of ProductRepository  
                       
6.DeliVeggie.Models - Contains common models

7.DeliVeggie.Tests - Test for the Service class inside DeliVeggie
