## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  __What database models do you know?__

    -   LDM (Logical Data Models)

        Logical data models represent the abstract structure of a domain of information. They are often diagrammatic in nature and are most typically used in business processes that seek to capture things of importance to an organization and how they relate to one another. Once validated and approved, the logical data model can become the basis of a physical data model and inform the design of a database.
    
        -   Hierarchical

            Data model in which the data is organized into a tree-like structure. The data is stored as records which are connected to one another through links. A record is a collection of fields, with each field containing only one value. The entity type of a record defines which fields the record contains.

            The hierarchical database model mandates that each child record has only one parent, whereas each parent record can have one or more child records.

        -   Network

            While the hierarchical database model structures data as a tree of records, with each record having one parent record and many children, the network model allows each record to have multiple parent and child records, forming a generalized graph structure.

            Until the early 1980s the performance benefits of the low-level navigational interfaces offered by hierarchical and network databases were persuasive for many large-scale applications, but as hardware became faster, the extra productivity and flexibility of the relational model led to the gradual obsolescence of the network model in corporate enterprise usage.

        -   Relational
            
            In the relational model of a database, all data is represented in terms of tuples (table rows), grouped into relations (tables).

            The purpose of the relational model is to provide a declarative method for specifying data and queries: users directly state what information the database contains and what information they want from it, and let the database management system software take care of describing data structures for storing the data and retrieval procedures for answering queries.

        -   Object

            An object database (also object-oriented database management system) is a database management system in which information is represented in the form of objects as used in object-oriented programming. Object databases are different from relational databases which are table-oriented. Object-relational databases are a hybrid of both approaches.


    -   PDM (Physical Data Models)

        A physical data model (or database design) is a representation of a data design which takes into account the facilities and constraints of a given database management system.

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?

        A relational DBMS is special system software that is used to manage the organization, storage, access, security and integrity of data.  This specialized software allows application systems to focus on the user interface, data validation and screen navigation or some other logic, unrelated to admnistering storedd data.  When there is a need to add, modify, delete or display data, the application system simply makes a "call" to the RDBMS.

1.  Define what is "table" in database terms.

        Representing data in rows. Each real-world individual of a class (for example, each customer who does business with our enterprise) is represented by a row of information in a database table. The row is defined in the relational model as a tuple that is constructed over a given scheme.

1.  Explain the difference between a primary and a foreign key.

        Primary Key: 

        It will not allow "Null values" and "Duplicate values"


        Foreign Key:

        It will allow "Null values" and "Duplicte values" and it refers to a primary key in anoter table.

1.  Explain the different kinds of relationships between tables in relational databases.

    -   one-to-one

        Both tables can have only one record on either side of the relationship. Each primary key value relates to only one (or no) record in the related table. They're like spouses—you may or may not be married, but if you are, both you and your spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.

    -   one-to-many
        
        The primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.

    -   many-to-many

        Each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.

1.  When is a certain database schema normalized?

        Normalization involves decomposing a table into less redundant (and smaller) tables without losing information; defining foreign keys in the old table referencing the primary keys of the new ones. The objective is to isolate data so that additions, deletions, and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.

        -   What are the advantages of normalized databases?
            
            -   Free the database of modification anomalies
            -   Minimize redesign when extending the database structure
            -   Avoid bias towards any particular pattern of querying

1.  What are database integrity constraints and when are they used?

    You can define integrity constraints to enforce business rules on data in your tables. Business rules specify conditions and relationships that must always be true, or must always be false. Because each company defines its own policies about things like salaries, employee numbers, inventory tracking, and so on, you can specify a different set of rules for each database table.

    When an integrity constraint applies to a table, all data in the table must conform to the corresponding rule. When you issue a SQL statement that modifies data in the table, DBMS ensures that the new data satisfies the integrity constraint, without the need to do any checking within your program.

1.  Point out the pros and cons of using indexes in a database.

    -   PROS

        -   faster searching in very large data
        -   quick access to data

    -   CONS

        -   slower when data is frequently inserted because indexes need to be updated
        -   more storage space requirement
        -   no performance gain when searching or accessing smaller data

1.  What's the main purpose of the SQL language?

    Special-purpose programming language designed for managing data held in a relational database management system (RDBMS), or for stream processing in a relational data stream management system (RDSMS).

1.  What are transactions used for?

    

    -   Example:



1.  What is a NoSQL database?

    

1.  Explain the classical non-relational data models.

    

1.  Give few examples of NoSQL databases and their pros and cons.

    

