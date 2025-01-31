
a simple inventory management system for a retail store using a C# console application. 

Product class with properties: 
ProductId (unique identifier) 
Name 
QuantityInStock 
Price 

Implement methods in the InventoryManager class: 
AddProduct(Product product): Adds a product to the inventory. 
RemoveProduct(int productId): Removes a product from the inventory based on its ID. 
UpdateProduct(int productId, int newQuantity): Updates the quantity of a product. 
ListProducts(): Displays all items in the inventory. 
GetTotalValue(): Calculates and returns the total value of the inventory. 


Constraints: 
Product IDs are positive integers. 
Prices are non-negative real numbers. 
Quantities are non-negative integers. 
Assume that the inventory starts empty without any products. 
