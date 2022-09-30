module.exports = {
	globDirectory: '.',
	globPatterns: [
		'**/*.{json,png,html,js}'
	],
	swDest: '.\js\nsw.js',
	ignoreURLParametersMatching: [
		/^utm_/,
		/^fbclid$/
	]
};