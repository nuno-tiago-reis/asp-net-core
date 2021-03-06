// Protractor configuration file, see link for more information
// https://github.com/angular/protractor/blob/master/lib/config.ts
// ReSharper disable InconsistentNaming

const {	SpecReporter } = require('jasmine-spec-reporter');

exports.config =
{
	allScriptsTimeout: 11000,
	specs:
	[
		'./source/**/*.e2e-spec.ts'
	],
	capabilities:
	{
		'browserName': 'chrome'
	},
	directConnect: true,
	baseUrl: 'https://localhost:44351/',
	framework: 'jasmine',
	jasmineNodeOpts:
	{
		showColors: true,
		defaultTimeoutInterval: 30000,
		print: function () {}
	},
	onPrepare()
	{
		require('ts-node').register
		({
			project: require('path').join(__dirname, './tsconfig.e2e.json')
		});
		jasmine.getEnv().addReporter(new SpecReporter
		({
			spec:
			{
				displayStacktrace: true
			}
		}));
	}
};