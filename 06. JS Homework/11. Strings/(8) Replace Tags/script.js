// ### Problem 8. Replace tags
// *	Write a JavaScript function that replaces in a HTML document given as string all the tags `<a href="…">…</a>` with corresponding tags `[URL=…]…/URL]`.

var html = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';
console.log(replaceAnchors(html));

function replaceAnchors (html) {
	return html.replace(/<a\s{1}href="(.*?)">(.*?)<\/a>/g, '[URL=' + '$1' + ']' + '$2' + '[/URL]');
}