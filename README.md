# Mirosoft.Utilities
This package contains the extension methods that I use almost in all .Net applications.
 Currnelty, There is only one class contains some of those extension methods but I intent to add more periodically.

# Installation

- nuget package    
  ```Install-Package Mirosoft.Utilities```

# Methods List
1. **Description\<T\>**   
   It returns the value of description attribute of enum. 
   If the enum item doesn't decorated with Description attribute, it returns empty string. 

2. **Summary**   
   It returns the substring of the original string with the provided length. 
   If the length value is greater than the length or original string, it returns the original string.
   
3. **ToLowerString**    
   It returns the lower case string of the provided object. If the input is null, it returns empty string.
   
4. **Serialize**   
   It serializes the provided object to JSON string.
   
5. **Deserialize\<T\>**   
   It deserializes the provided string to specified Type as **IEnumerable\<T\>**. It has another overload that accepts **string[]**.
   
6. **Format**   
   It formats the provided value to string. It has many versions to format **date**, **date?**, **double**, **int**, and **long** values.
   **Note** As I'm in middle east, we usally use dd-MM-yyyy date format.   
   ex.   
   ```C#
   DateTime.Now.Format(true); // true to show time part
   // 10-08-2018 10:30PM   
   
   var _long = 1452874569527;
   _long.Format(); //1,452,874,569,527
   ```  

 7. **PeriodInDays**   
    It returns the total duration in year month day format.    
    ex.   
    ```C#
    var period = DateTime.Now.AddDays(-500).PeriodInDays(DateTime.Now);
    //1 year 4 month 15 day
    var period = DateTime.Now.AddDays(-1).PeriodInDays(DateTime.Now);
    //0 year 0 month 1 day
    ```
