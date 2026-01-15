# Changelog

## 3.0.1 (2026-01-15)

Full Changelog: [v0.2.0...v3.0.1](https://github.com/browserbase/stagehand-net/compare/v0.2.0...v3.0.1)

### ⚠ BREAKING CHANGES

* **client:** change casing of some identifiers
* **client:** **Migration:** Only use all-caps in PascalCase for two-letter acronyms. Otherwise, use a capital letter for the first letter and lowercase letters for the rest.
* **client:** add pagination

### Features

* [STG-1053] [server] Use fastify-zod-openapi + zod v4 for openapi generation ([d6eac22](https://github.com/browserbase/stagehand-net/commit/d6eac22a4b4365417857ea109f15fd0f48df8fe9))
* /end endpoint returns empty object ([5fc70d1](https://github.com/browserbase/stagehand-net/commit/5fc70d1484d251a460b53979fc29d3eab7efa761))
* Added optional param to force empty object ([e0b8d9a](https://github.com/browserbase/stagehand-net/commit/e0b8d9abd841aef7075cf9668b177597a2c0756a))
* **api:** manual updates ([306367d](https://github.com/browserbase/stagehand-net/commit/306367d0c1dd74a410f569382d95a4341fa9a843))
* **api:** manual updates ([ae7ad32](https://github.com/browserbase/stagehand-net/commit/ae7ad3207f2713d08fd2c0a08e48d462c9a74011))
* **api:** manual updates ([7c12ff9](https://github.com/browserbase/stagehand-net/commit/7c12ff9d98423339e572a9c40592a3cd4c3683c8))
* **api:** manual updates ([c0d112e](https://github.com/browserbase/stagehand-net/commit/c0d112ee75846a82da2ba6852c8dfd5a6ad5d494))
* **api:** manual updates ([851f6e6](https://github.com/browserbase/stagehand-net/commit/851f6e65415f1b7b2e427c1469f940f97cde2df1))
* **api:** manual updates ([d4c5a5d](https://github.com/browserbase/stagehand-net/commit/d4c5a5dd0a09bde860aad295335eff8816aa9d9b))
* **api:** manual updates ([d2a5fe7](https://github.com/browserbase/stagehand-net/commit/d2a5fe7c7e372d26a6c2d1c0050f32ae3b92a67c))
* **api:** manual updates ([15de348](https://github.com/browserbase/stagehand-net/commit/15de348158a1df3af19dc28f9ae148a4f29fd4d6))
* **api:** manual updates ([44c3939](https://github.com/browserbase/stagehand-net/commit/44c39397b26549cf7b0cc901ba6732dffed9b987))
* **api:** manual updates ([b658896](https://github.com/browserbase/stagehand-net/commit/b6588969238c0e66e9910675a9738400e51e6923))
* **api:** manual updates ([5ee5eee](https://github.com/browserbase/stagehand-net/commit/5ee5eee21355451e2a14bfde8d0d968a94f81edb))
* **api:** manual updates ([28fab2a](https://github.com/browserbase/stagehand-net/commit/28fab2ab59bb42ab446e67a34e440dcd11b793e7))
* **client:** add helper functions for raw messages ([433bd5b](https://github.com/browserbase/stagehand-net/commit/433bd5beb3f5d9a291940d7b4966d69cd9300cd9))
* **client:** add more `ToString` implementations ([f46c25f](https://github.com/browserbase/stagehand-net/commit/f46c25fba480636377bc480611234dcf13087bf6))
* **client:** add multipart form data support ([2b25395](https://github.com/browserbase/stagehand-net/commit/2b25395d88f9f33841b7f769491b6805c50c9db4))
* **client:** add pagination ([f1d1d39](https://github.com/browserbase/stagehand-net/commit/f1d1d3912701f299d10a3c86ceb340540faf111a))
* **client:** support accessing raw responses ([2dd9ae9](https://github.com/browserbase/stagehand-net/commit/2dd9ae9a23e5cab9d2331cd50fa74f1be1976f45))
* Removed requiring x-language and x-sdk-version from openapi spec ([47afc4d](https://github.com/browserbase/stagehand-net/commit/47afc4dab21b1d4aba0f62135eb62b9c9cd7c9f5))
* Using provider/model syntax in modelName examples within openapi spec ([7843691](https://github.com/browserbase/stagehand-net/commit/784369113d8f010409f32c1c4d57470c25b48f59))


### Bug Fixes

* **ci:** don't throw an error about missing lsof ([b713f19](https://github.com/browserbase/stagehand-net/commit/b713f191699bc1de36cb9b30ac4047e47b9257c2))
* **ci:** run tests properly on windows ([dde235e](https://github.com/browserbase/stagehand-net/commit/dde235ef02c9bc744b6b1d1d9baf422a2a854083))
* **client:** add missing serializer options ([0dccfe7](https://github.com/browserbase/stagehand-net/commit/0dccfe72d7e0bd0ee2397f728ce0499a833884c4))
* **client:** copy path params in params copy constructors ([d850ec0](https://github.com/browserbase/stagehand-net/commit/d850ec07f2321eb6c9662a5cf50ed3b002626f66))
* **client:** ensure deep immutability for deep array/dict structures ([9762667](https://github.com/browserbase/stagehand-net/commit/976266732fdebcb9f88ef93d42b901f29d8d42c8))
* **client:** freeze models on property access ([8fc36d3](https://github.com/browserbase/stagehand-net/commit/8fc36d37b66192d0bf453c0b7d5055d67aba6440))
* **client:** rethrow SSE errors as proper exception type ([c50e3b7](https://github.com/browserbase/stagehand-net/commit/c50e3b72f7142e2220442d95a0dbcb721b054389))
* **client:** throw api enum errors as invalid data exception ([f3bb4ec](https://github.com/browserbase/stagehand-net/commit/f3bb4ec35327b29105a8ed66b38225f69771172f))
* **client:** union switch method type checks ([3f92781](https://github.com/browserbase/stagehand-net/commit/3f927815ef76041405d60830944d8792aaf30d2b))
* **client:** use readonly type for param ([28b8292](https://github.com/browserbase/stagehand-net/commit/28b82927dbcf2241f4a6e7b11969b15c4ec7fe4b))
* **internal:** remove redundant line ([e80e96c](https://github.com/browserbase/stagehand-net/commit/e80e96cfa96e1d20e34f373ff7df943855f4bf29))
* **internal:** remove roundtrip tests for multipart params ([4fe34c3](https://github.com/browserbase/stagehand-net/commit/4fe34c3f1e3ba17c339cdb5e0c23d6c4cffb9a86))
* **internal:** test nullability warnings ([b642116](https://github.com/browserbase/stagehand-net/commit/b6421161a32eb5e549a301377deb384362cc438d))


### Performance Improvements

* **client:** add json deserialization caching ([9762667](https://github.com/browserbase/stagehand-net/commit/976266732fdebcb9f88ef93d42b901f29d8d42c8))


### Chores

* **client:** consistently use serializer options ([ce7f682](https://github.com/browserbase/stagehand-net/commit/ce7f682a93ebb93a4669bfaac8ac2f116a622004))
* **client:** improve object instantiation ([8ed48eb](https://github.com/browserbase/stagehand-net/commit/8ed48eb800d93bfaca677e4ae70adc0b7592e358))
* **client:** refactor union instantiation ([aa7b412](https://github.com/browserbase/stagehand-net/commit/aa7b41228c4bc2f2d464a0036b096c6e01466644))
* **client:** use mutable collections for union deserialization ([df899c7](https://github.com/browserbase/stagehand-net/commit/df899c71a459f7253086f4226a892029f7b0d79b))
* **internal:** add files to sln so they show up in visual studio ([bad2a60](https://github.com/browserbase/stagehand-net/commit/bad2a608e116aca685eae8ad2d53e26268321a7a))
* **internal:** share csproj properties with dir build props ([b642116](https://github.com/browserbase/stagehand-net/commit/b6421161a32eb5e549a301377deb384362cc438d))
* **internal:** suppress a diagnostic ([59c2005](https://github.com/browserbase/stagehand-net/commit/59c20056da1ab5bc9ef6dbaf5a3d6a95be2d64b2))
* **internal:** turn off overzealous lints ([f63f87c](https://github.com/browserbase/stagehand-net/commit/f63f87cb647ecd7d4a656ab97bc99c98b226c5be))
* **internal:** use `Random.Shared` in newer .NET versions ([ff5ccd3](https://github.com/browserbase/stagehand-net/commit/ff5ccd38c5381a81e619b407bc8c52f7d1efea07))
* **internal:** use better test examples ([b642116](https://github.com/browserbase/stagehand-net/commit/b6421161a32eb5e549a301377deb384362cc438d))
* **readme:** remove beta warning now that we're in ga ([d101196](https://github.com/browserbase/stagehand-net/commit/d101196b18b5ea1e26a3553571c57958be30f0aa))
* rename some identifiers ([69eb5fd](https://github.com/browserbase/stagehand-net/commit/69eb5fd4716dd278a20c73787b13a4b904e8f38e))


### Documentation

* add contributing.md ([cbfb9bb](https://github.com/browserbase/stagehand-net/commit/cbfb9bbeca3e0f65d6da546b35e509cc0d1dfe82))
* add more examples ([b73f054](https://github.com/browserbase/stagehand-net/commit/b73f0543e9d6bfb8f9c21851f7d32dfb75f258c5))
* add raw responses to readme ([5b82ba0](https://github.com/browserbase/stagehand-net/commit/5b82ba0741d5da13ee007d5f6afdd7e23679a5eb))


### Refactors

* **client:** add `JsonDictionary` identity methods ([3b4f102](https://github.com/browserbase/stagehand-net/commit/3b4f10272c09c50c57501846fceb514474f1f8fb))
* **client:** change casing of some identifiers ([1dab110](https://github.com/browserbase/stagehand-net/commit/1dab110e3497e80f6165461e5685f03457bdae4a))
* **client:** make unions implement `ModelBase` ([699b29d](https://github.com/browserbase/stagehand-net/commit/699b29d7dcc9a4a8f967fe88d86d23f75b734fd9))
* **internal:** `JsonElement` constant construction ([fdb9725](https://github.com/browserbase/stagehand-net/commit/fdb972594f7bf99598a9ba24b2a7b5aa61a476fe))

## 0.2.0 (2025-12-16)

Full Changelog: [v0.1.0...v0.2.0](https://github.com/browserbase/stagehand-net/compare/v0.1.0...v0.2.0)

### Features

* **api:** manual updates ([b06c260](https://github.com/browserbase/stagehand-net/commit/b06c260afc9a91b6d49e74b1fb9384506c47e31b))

## 0.1.0 (2025-12-16)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/browserbase/stagehand-net/compare/v0.0.1...v0.1.0)

### Features

* **api:** manual updates ([984770a](https://github.com/browserbase/stagehand-net/commit/984770a24f7c7ac5b1ca18d924a193a497866d57))
* **api:** manual updates ([f992bea](https://github.com/browserbase/stagehand-net/commit/f992bea9211ea5de011567ea75844e77b6b91d97))
* **api:** manual updates ([96b1343](https://github.com/browserbase/stagehand-net/commit/96b134317f13e67397cde474497b8883b4f26736))
* **api:** manual updates ([199fe34](https://github.com/browserbase/stagehand-net/commit/199fe345a769eb75364be6eaa0f76cb242b495aa))
* **api:** manual updates ([b846afe](https://github.com/browserbase/stagehand-net/commit/b846afe2ce90019bf840ab931287a0013f018bb3))
* **api:** manual updates ([a513e8b](https://github.com/browserbase/stagehand-net/commit/a513e8b9991892ccc3c27436c1d77aec7ae2e8f3))
* **api:** manual updates ([5af970a](https://github.com/browserbase/stagehand-net/commit/5af970afa4317dafc7b2a709f910618b2c20372d))
* **api:** manual updates ([9473f06](https://github.com/browserbase/stagehand-net/commit/9473f0683b1176dd94c5e0badeccb2910b2a43ae))
* **api:** manual updates ([c48ae76](https://github.com/browserbase/stagehand-net/commit/c48ae760513f1541e53556fd179cc0404949d4c7))
* **api:** tweak branding and fix some config fields ([5281a47](https://github.com/browserbase/stagehand-net/commit/5281a47f368ece94647efa665e62d492129900f9))


### Chores

* configure new SDK language ([a122123](https://github.com/browserbase/stagehand-net/commit/a122123fa85c0e240db0a523a42a47ea41a2ad15))
