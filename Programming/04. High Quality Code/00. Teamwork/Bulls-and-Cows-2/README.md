Refactoring Documentation for Project “Bulls-and-Cows”
======================================================
Team “Bulls-and-Cows-2”
-----------------------
1.  Redesigned the project structure: 
    -   Renamed the project to `.....`.
    -   Renamed the main class `Program` to `......`.
    -   …
2.  Reformatted the source code:
    -   Removed all unneeded empty lines, e.g. in the method `........()`.
    -   Inserted empty lines between the methods.
    -   Split the lines containing several statements into several simple lines, e.g.:
    
    Before:
    
        if (input\[i\] != ' ') break;
        
    After:

        if (input\[i\] != ' ')
        {
            break;
        }
    
    -   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
    -   Put **{** and **}** after all conditionals and loops (when missing).
    -   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
    -   ...
3.  Renamed variables:
    -   ...
4.  Introduced constants:
    -   ...
5.  Extracted the method `...()` from the method `..()`.
6.  Introduced class `....` and moved all related functionality in it.
7.  Moved method `........()` to separate class `...`.
8.  …
