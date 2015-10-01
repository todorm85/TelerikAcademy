/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and isbn
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book isbn
 *	Book isbn is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
	var library = (function() {
		var books = [];
		var categories = [];

		function orderByID(a, b) {
			return a.ID - b.ID;
		}

		function listBooks() {
			function filterBooksByOption(book) {
				if (option['category'] && book['category'] === option['category'] ||
						option['author'] && books['author'] === option['author'] ||
						option['all']) {
					return true;
				} else {
					return false;
				}
			}

			var option = arguments[0];

			if (arguments.length === 0) {
				return books.slice().sort(orderByID);
			} else {
				return books.filter(filterBooksByOption).sort(orderByID);
			}
		}

		function addBook(book) {
			(function validateBook(book) {
				function containsTitle(book) {
					if (book.title === title) {
						return true;
					} else {
						return false; 
					}
				}

				var title = book.title,
					author = book.author,
					isbn = book.isbn,
					category = book.category;

				if (title === undefined || (typeof title !== 'string') || 
						title.length < 2 || title.length > 100 || books.some(containsTitle)) {
					throw 'error';
				}

				if (category === undefined || (typeof category !== 'string') || 
						category.length < 2 || category.length > 100) {
					throw 'error';
				}

				if (author === undefined || (typeof author !== 'string') || author.length === 0) {
					throw 'error';
				}

				(function isValidisbn(isbn) {
					function containsisbn(book) {
						if (book.isbn === isbn) {
							return true;
						} else {
							return false; 
						}
					}

					if (isbn === undefined || books.some(containsisbn) ||
							!(isbn.length === 10 || isbn.length === 13)) {
						throw 'Error';
					}
				
					// check if only digits
					if (isbn.replace(/\d*/, '') !== '') {
						throw 'Error';
					}
				}(isbn));

			} (book));

			(function addCategory(book) {
				function containsCategory(category) {
					if (category.name === categoryName) {
						return true;
					} else {
						return false;
					}
				}

				var categoryName = book.category,
					category;
	
				if (categories.some(containsCategory) === false) {
					category = {
						name: categoryName,
						ID: categories.length + 1
					}
					
					categories.push(category);
				}
			} (book));

			book.ID = books.length + 1;
			books.push(book);
			return book;
		}

		function listCategories() {
			function mapCategories(category) {
				return category.name;
			}
			return categories.slice().sort(orderByID).map(mapCategories);
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());

	// var book1 = {
	// 	title: 'First',
	// 	author: 'FirstAuthor',
	// 	category: 'FirstCategory',
	// 	isbn: '1234567890'
	// };

	// var book2 = {
	// 	title: 'Second',
	// 	author: 'SecondAuthor',
	// 	category: 'SecondCategory',
	// 	isbn: '1234567890123'
	// };

	// library.books.add(book1);
	// library.books.add(book2);

	// console.log(library.books.list({category: 'First'}));
	// // console.log(library.categories.list());

	return library;
}
module.exports = solve;

// solve();

