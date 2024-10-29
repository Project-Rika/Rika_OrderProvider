# Rika_OrderProvider

###Exempel på ett JSON-objekt och vilka parametrar som ska finnas

```json
{
  "OrderID": "12345",
  "OrderDate": "2023-10-29",
  "TotalAmount": 499.99,
  "PaymentMethod": "CreditCard",
  "ShipmentMethod": "Express",
  "OrderCustomer": {
    "Name": "John Doe",
    "Email": "john.doe@example.com",
    "Phone": "+1234567890"
  },
  "OrderAddress": {
    "Street": "123 Main St",
    "City": "Stockholm",
    "PostalCode": "12345",
    "Country": "Sweden"
  },
  "OrderProducts": [
    {
      "ProductID": "001",
      "ProductName": "Laptop",
      "Quantity": 1,
      "Price": 399.99
    },
    {
      "ProductID": "002",
      "ProductName": "Mouse",
      "Quantity": 1,
      "Price": 29.99
    },
    {
      "ProductID": "003",
      "ProductName": "Keyboard",
      "Quantity": 1,
      "Price": 69.99
    }
  ]
}
