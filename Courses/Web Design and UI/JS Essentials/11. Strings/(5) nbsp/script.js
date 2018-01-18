// ### Problem 5. nbsp
// *	Write a function that replaces non breaking white-spaces in a text with `&nbsp`;

var txt = 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius voluptate, neque corporis itaque modi possimus, molestiae, repellat voluptates perspiciatis veniam iure nisi asperiores quaerat. Blanditiis facilis deleniti est sapiente nobis.';
txt = escapeWhiteSpace(txt);
console.log(txt);

function escapeWhiteSpace (txt) {
	var whiteSpaceChar = '&nbsp';
	return txt.replace(/\s/g, whiteSpaceChar);
}