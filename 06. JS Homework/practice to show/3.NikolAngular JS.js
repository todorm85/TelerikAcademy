function solve(inArr) {

	var propsCount = inArr[0] | 0;
	var viewLinesCount = inArr[propsCount + 1];



	// extract models
	var modelArrs = {};
	var propName;
	var propValue;
	for (var i = 1; i <= propsCount; i += 1) {
		var currentLine = inArr[i];
		propName = currentLine.match(/.+?\b/)[0];
		propValue = /-(.*$)/.exec(currentLine)[1].split(';');
		modelArrs[propName] = propValue;
	}



	// extract templates
	var sourceView = inArr.slice(propsCount + 2).join('\n');
	var templates = {};
	var templateRE = /<nk-template name="(.+?)">([^]+?)<\/nk-template>\n/g
	// p1: template name, p2: template text
	sourceView = sourceView.replace(templateRE,function (match,p1,p2) {
		// add the template to associative array, but first remove one tab from beginning of each line of template text p2
		// $1: the new line symbol, which shouldn`t be removed, but must be matched, since we want to remove tabbing only from the beginning
		templates[p1] = removeTab(p2).replace(/^\n/,'');
		return '';
	});



	markEscapes();



	// insert templates
	sourceView = sourceView.replace(/( *?)<nk-template render="(.+?)" \/>/gm,
		function (match, tabbing, templateName) {
			return templates[templateName].replace(/^/gm, tabbing);
		});



	markEscapes();



	// Process Conditions
	var ifRE = /\s*<nk-if condition="(.+?)">([^]+?)<\/nk-if>/gm
	sourceView = sourceView.replace(ifRE, function (match, condition, tagText) {
		if (modelArrs[condition][0] === 'true') {
			return removeTab(tagText);
		} else {
			return '';
		}
	});



	// Process loops
	var loopRE = /\s*<nk-repeat for="(.+?) in (.+?)">([^]+?)<\/nk-repeat>/gm
	sourceView = sourceView.replace(loopRE
		, function (match, propInTagName, propName, tagText) {

			var finalTagText = '';

			for (var i = 0; i < modelArrs[propName].length; i+=1) {
				var newTagText = tagText;
				newTagText = newTagText
					.replace(new RegExp('<nk-model>' + propInTagName + '<\/nk-model>','g')
						,modelArrs[propName][i]);
				finalTagText += removeTab(newTagText).replace(/\s*$/,'');
			}

			return finalTagText;
	});



	markEscapes();



	// process all models
	sourceView = sourceView.replace(/( *)<nk-model>(.+?)<\/nk-model>/g,
		function (match, tabbing, modelName) {
			if (modelArrs[modelName] !== undefined) {
				return modelArrs[modelName][0].replace(/^/, tabbing);
			} else {
				return match;
			}
		});



	// unmark all escapes
	sourceView = sourceView.replace(/\{\{\}/g, '{{<nk-');



	// remove all escapes
	sourceView = sourceView.replace(/(?:\{\{)|(?:\}\})/g, '');
	console.log(sourceView);



	function removeTab (txt, count) {
		count = count || 1;
		// remove tab from beginning of each line, but preserve newlines
		for (var i = 0; i < +count; i+=1) {
			txt = txt.replace(/(\n)\s{4}/g,'$1');
		}
		// before return remove the last newline char
		return txt.replace(/\n$/,'');
	}

	function markEscapes () {
		sourceView = sourceView.replace(/\{\{<nk-/g, '{{}');
	}
}

var test0 = ['6', 'title-Telerik Academy', 'showSubtitle-true', 'subTitle-Free training', 'showMarks-false', 'marks-3;4;5;6', 'students-Ivan;Gosho;Pesho', '42', '<nk-template name="menu">', '    <ul id="menu">', '        <li>Home</li>', '        <li>About us</li>', '    </ul>', '</nk-template>', '<nk-template name="footer">', '    <footer>', '        Copyright Telerik Academy 2014', '    </footer>', '</nk-template>', '<!DOCTYPE html>', '<html>', '<head>', '    <title>Telerik Academy</title>', '</head>', '<body>', '    <nk-template render="menu" />', '', '    <h1><nk-model>title</nk-model></h1>', '    <nk-if condition="showSubtitle">', '        <h2><nk-model>subTitle</nk-model></h2>', '        <div>{{<nk-model>subTitle</nk-model>}} ;)</div>', '    </nk-if>', '', '    <ul>', '        <nk-repeat for="student in students">', '            <li>', '                <nk-model>student</nk-model>', '            </li>', '            <li>Multiline <nk-model>title</nk-model></li>', '        </nk-repeat>', '    </ul>', '    <nk-if condition="showMarks">', '        <div>', '            <nk-model>marks</nk-model> ', '        </div>', '    </nk-if>', '', '    <nk-template render="footer" />', '</body>', '</html>'];

var test1 = ['0', '15', '<div>', '    <p>', '    {{<nk-if condition="pesho">}}', '        {{escaped}} dude', '    </p>', '    <p>', '    {{<nk-template render="pesho">}}', '    </p>', '    <p>', '    {{<nk-repeat for="pesho in peshos">}}', '        {{escaped}} in comment', '    </p>', '</div>'];

var test6 = ['2', 'someNumbers-1;2;3;4;5', 'someTechs-asp.net;mvc;angular;node;c sharp', '14', '<div>', '    <span>Some bulsh*t text</span>', '    <br />', '    <nk-repeat for="number in someNumbers">', '        <span><nk-model>number</nk-model> da ima</span>', '        <span>only <nk-model>number</nk-model></span>', '    </nk-repeat>', '    <br />', '    <div>', '        <span>More bulsh*t text</span>', '        <nk-repeat for="tech in someTechs">', '            <span><nk-model>tech</nk-model> is cool</span>', '            <span>and <nk-model>tech</nk-model> is mama</span>', '        </nk-repeat>', '    <div>', '</div>'];

solve(test6);