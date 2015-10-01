// ### Problem 7. Parse URL
// *	Write a script that parses an URL address given in the format: `[protocol]://[server]/[resource]`
// 	and extracts from it the `[protocol]`, `[server]` and `[resource]` elements.
// *	Return the elements in a JSON object.

var url = 'http://telerikacademy.com/Courses/Courses/Details/239';
var extractedUrlItems = extractUrl(url);
console.log(extractedUrlItems.protocol);
console.log(extractedUrlItems.server);
console.log(extractedUrlItems.resource);

function extractUrl(url) {
	var protocol;
	var server;
	var resource;

	url.replace(/([^:]*)\:\/\/(.*?)\/(.*)/, extractor);

	function extractor(match, p1, p2, p3, offset, string) {
		protocol = p1;
		server = p2;
		resource = p3;
	}

	return {protocol: protocol, server: server, resource: resource};
}