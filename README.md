# SQLTemporalTablesDemo
A Short Demo for SQL temporal tables

# What are SQL  system-versioned Temporal Tables
 SQL Server 2016.


# How To Use Temporal Tables
First we need turn on the feature in SQL via SQL server managment studio.
or via entityframeworkcore by using .IsTemporal() function on the tables that you desire to keep track of changes.
After that we can use them in queries.
##Pros
Easy to use
Plug and play

## Cons
The use of temporal tables will increase the amount of data drastically if lot of changes are made to existing rows.
It is not possible to modify the history table directly.
Temporal tables supports blob data types, this can have an impact on the performance due to their size, so be careful before adding those types.
Removing a column in a temporal table will remove the corresponding column in the history table too. E.g. if the country column is dropped from the Address table,
it will also drop the country column from the AddressHistory.