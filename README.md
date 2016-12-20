# KPMTestEMS
<p align ="center"><img src="https://github.com/kostovhg/KPMTestEMS/blob/master/KPMTestEMS/Content/Images/Logo01.png" width="100px"></p>
<p>&nbsp;</p>
[![Travis branch](https://img.shields.io/travis/rust-lang/rust/master.svg?style=plastic)]()
[![Scrutinizer Coverage](https://img.shields.io/scrutinizer/coverage/g/filp/whoops.svg?style=plastic)]()
[![Version](https://img.shields.io/badge/ver-0.0.0--pre--alfa-red.svg)]()
<p>&nbsp;</p>
## Description:
System should provide options for clients to order custom products by select between different parameters of main product, traders to manage client's orders and to create products parameters.
<p>&nbsp;</p>
### Done:
1. Anonimous views - [x] ViewProducts
2. Client views - ViewProducts, CreateOrder, ManageProfile, ListOrders,
3. Trader views - ListOrders,

### ToDo:
1. Anonimous views - BrowseProducts
2. Client views - EditOrder
3. Trader views - EditProducts, EditOrders
4. Admin views - EditProfiles, EditRoles,
5. Fixes - 
    1. Unification of pages (bootstrap) - sm-4 in CreateOder for Due Date and Comment
    2. Datepicker and dates in Create Order
    3. Handle errors when sending models to controllers
    4. Remove search field from client order list
    5. Change buttons for Admin and Trader in Manage/Index
