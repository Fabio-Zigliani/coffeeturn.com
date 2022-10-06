module.exports = {
	globDirectory: '.',
	globPatterns: [
		'**/*.{json,png,html,js}'
	],
	swDest: '.\js\pwabuilder-sw.js',
	ignoreURLParametersMatching: [
		/^utm_/,
		/^fbclid$/
	]
};