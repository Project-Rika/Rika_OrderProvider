# Rika_OrderProvider

###Exempel på ett JSON-objekt och vilka parametrar som ska finnas

```json
{
  "TotalAmount": 499.99,
  "PaymentMethod": "CreditCard",
  "ShipmentMethod": "Express",
  "OrderCustomer": {
    "Name": "John Doe",
    "Email": "john.doe@example.com",
    "Phone": "+1234567890"
  },
  "OrderAddress": {
    "Street": "vägvägen 1",
    "City": "Stockholm",
    "PostalCode": "12345",
    "Country": "Sweden"
  },
  "OrderProducts": [
    {
      "ProductID": "001",
      "ProductName": "Jacket",
      "Quantity": 1,
      "Price": 399.99
    },
    {
      "ProductID": "002",
      "ProductName": "Shoes",
      "Quantity": 1,
      "Price": 29.99
    },
    {
      "ProductID": "003",
      "ProductName": "Sweater",
      "Quantity": 1,
      "Price": 69.99
    }
  ]
}
