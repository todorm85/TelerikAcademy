# What do namespaces represent in an XML document? What are they used for?

XML Namespaces provide a method to avoid element name conflicts.

In XML, element names are defined by the developer. This often results in a conflict when trying to mix XML documents from different XML applications.

Name conflicts in XML can easily be avoided using a name prefix. When using prefixes in XML, a namespace for the prefix must be defined. The namespace can be defined by an xmlns attribute in the start tag of an element. The namespace declaration has the following syntax. xmlns:prefix="URI". The namespace URI is not used by the parser to look up information. The purpose of using an URI is to give the namespace a unique name.However, companies often use the namespace as a pointer to a web page containing namespace information. When a namespace is defined for an element, all child elements with the same prefix are associated with the same namespace.

Namespaces can also be declared in the XML root element.

