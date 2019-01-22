# SQL - Sequel or sometimes pronounced Squirrel

This is a beginners guide to Structured Query Language (SQL) *- Not to be confused with MS-SQL (Microsoft SQL Server)*

> SQL is the Query language used most often when interacting with relational databases.

In this tutorial we will be looking at: 
- how to create and design a simple database
- interacting with a relational database using SQL
- what is an ORM and how to use it
- **BONUS** - caching my data using an in-memory data structure store


---

## My timesheet

We will be creating a simple timesheet app to demonstrate relation data.

Consider the following data to be captured:
> - Name
> - Surname
> - Project
> - Date
> - Time start
> - Time end
> - Duration
> - Description
> - Billable (true/false)

*A table structure for that **could** be...*

Name | Surname | Client | Project | Date | Time Started | Time ended | Duration | Description | Billable
--- | --- | --- | --- | --- | --- | --- | --- | --- | ---
John | Doe | Client X | Website | 2019-01-22 | 09:00 | 11:00 | 120 | I was rocking HTML5  | YES
John | Doe | Client X | API | 2019-01-22 | 13:00 | 17:00 | 240 | Grafting on golang api  | YES

### What we will be doing

1. Create database and SQL login
2. Create and Run Initial migration
3. Run Project and connect to SQL Database
4. Insert and read some data
5. Add Redis connection to project ([Example](https://docs.microsoft.com/en-us/azure/azure-cache-for-redis/cache-web-app-howto))
6. Save some data into Redis
7. Read some data from Redis