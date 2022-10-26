module.exports = {
	globDirectory: '.',
	globPatterns: [
		'**/*.{json,png,html,js,jpg,css}'
	],
	swDest: '.\js\pwabuilder-sw.js',
	ignoreURLParametersMatching: [
		/^utm_/,
		/^fbclid$/
	]
};