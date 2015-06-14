// ### Problem 9. Extract e-mails
// *	Write a function for extracting all email addresses from given text.
// *	All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
// *	Return the emails as array of strings.

var txt = '1Lorem@mail.com, Lo. 2rem@mail.com, 3Lorem@mail., @4ipsum.com, 5Lo@remmail.com, 6lo.rem@mail.com';
var mailPattern = /[\w.]+?@[\w]+?\.[\w]+/g;

var mailsArr = extractText (txt, mailPattern);

console.log(mailsArr);

function extractText (txt, regExPattern) {
	
	var matchedArr = txt.match(regExPattern);
	
	return matchedArr;
}