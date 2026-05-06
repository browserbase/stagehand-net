# Changelog

## 3.20.0 (2026-05-06)

Full Changelog: [v3.19.3...v3.20.0](https://github.com/browserbase/stagehand-net/compare/v3.19.3...v3.20.0)

### Features

* [feat]: add `ignoreSelectors` to `extract()` ([a9b327f](https://github.com/browserbase/stagehand-net/commit/a9b327f17942b28a16800c3dd93b569bb1bac6dc))
* [STG-1808] Deprecate Browserbase project ID ([1571286](https://github.com/browserbase/stagehand-net/commit/15712866df03d50e920ab9f71e24e30d7b17e455))
* remove experimental requirement on agent variables ([#2079](https://github.com/browserbase/stagehand-net/issues/2079)) ([1c3a03c](https://github.com/browserbase/stagehand-net/commit/1c3a03c6961d3c4fab99e2852ce0ea4dc4778444))

## 3.19.3 (2026-05-05)

Full Changelog: [v3.18.0...v3.19.3](https://github.com/browserbase/stagehand-net/compare/v3.18.0...v3.19.3)

### Features

* [STG-1798] feat: support Browserbase verified sessions ([4ba175f](https://github.com/browserbase/stagehand-net/commit/4ba175f797ac9197f86d412217aaa38ec74a4c45))
* Bedrock auth passthrough ([37699f0](https://github.com/browserbase/stagehand-net/commit/37699f057d6bbc547df62b84888dea3726297d7f))
* **client:** enable gzip decompression ([49ab455](https://github.com/browserbase/stagehand-net/commit/49ab4556442cad5938efc0596b3654875b0ba312))
* Replace default model used in server-v3 api spec examples ([9b1f30b](https://github.com/browserbase/stagehand-net/commit/9b1f30b10bc25a590209487b356c09d94c9f366a))
* Revert "[STG-1573] Add providerOptions for extensible model auth ([#1822](https://github.com/browserbase/stagehand-net/issues/1822))" ([4a70f7c](https://github.com/browserbase/stagehand-net/commit/4a70f7c79569fbdaf91551e34db95ea87685b30b))
* support setting headers via env ([61b971d](https://github.com/browserbase/stagehand-net/commit/61b971d2341b0eeb200b41ad2657b8b6e61317ad))


### Bug Fixes

* **client:** allow cancelling when enumerating over an http response ([9184144](https://github.com/browserbase/stagehand-net/commit/9184144f8562fb9cf341787386c97de7db753a2b))
* **client:** don't overzealously validate union variants when deserializing ([9278721](https://github.com/browserbase/stagehand-net/commit/92787213b4c96f7cbb42dfa05bedba8cfd9f671b))
* **tests:** round-trip urls correctly ([4f0fb62](https://github.com/browserbase/stagehand-net/commit/4f0fb6240ca759edbdf6a0fd3b2abadb1d877011))

## 3.18.0 (2026-03-25)

Full Changelog: [v3.0.2...v3.18.0](https://github.com/browserbase/stagehand-net/compare/v3.0.2...v3.18.0)

### Features

* [feat]: add support for local caching of agent when using api (2) ([2cafd02](https://github.com/browserbase/stagehand-net/commit/2cafd023d69d10ff33a239f26d72e4eab17ed2de))
* [fix]: add `useSearch` & `toolTimeout` to stainless types ([7293763](https://github.com/browserbase/stagehand-net/commit/7293763097064afb7943c0f32b579940e7418d5a))
* [STG-1607] Yield finished SSE event instead of silently dropping it ([5b6b3fc](https://github.com/browserbase/stagehand-net/commit/5b6b3fcd8b7197d78b17f32f91fbcfd08396aaaa))
* add auto-bedrock support based on bedrock/provider.model-name ([2627a23](https://github.com/browserbase/stagehand-net/commit/2627a232681be0a7fc3469bca31852decc87a9a6))
* Add bedrock to provider enum in Zod schemas and OpenAPI spec ([9b19bf9](https://github.com/browserbase/stagehand-net/commit/9b19bf91f2393a3163b0c58582f32b59f11f0a5b))
* Add executionModel serialization to api client ([6171867](https://github.com/browserbase/stagehand-net/commit/617186772fb6e704f04c7f0b8aa4ea6fff8400ba))
* Add explicit SSE event names for local v3 streaming ([7239f7a](https://github.com/browserbase/stagehand-net/commit/7239f7a4c85ee42fb3ddb7f68c1a82e0f4f3a483))
* Add missing cdpHeaders field to v3 server openapi spec ([a417fc8](https://github.com/browserbase/stagehand-net/commit/a417fc83d3c26537057aa998fba24309cd830b09))
* add v3 integration tests matching cloud exactly ([a5a3ab7](https://github.com/browserbase/stagehand-net/commit/a5a3ab7acb6fadd38b01160fba7eb580e5b7a9e2))
* **api:** manual updates ([51b11b1](https://github.com/browserbase/stagehand-net/commit/51b11b137bd6a3a348a1db25e3066a6f19bf4624))
* **client:** add `ToString` and `Equals` methods ([44c5549](https://github.com/browserbase/stagehand-net/commit/44c554907ae79cd91847f4c0611e1a04866053cf))
* **client:** add `ToString` to `ApiEnum` ([20899c6](https://github.com/browserbase/stagehand-net/commit/20899c6f1f10e4fef11da62dd21a0b480e18020b))
* **client:** add equality and tostring for multipart data ([7e64d5f](https://github.com/browserbase/stagehand-net/commit/7e64d5fa069e6372831812d43b25bb753ce6ada2))
* **client:** add Equals and ToString to params ([80c81af](https://github.com/browserbase/stagehand-net/commit/80c81af5710b875c5d8628fa5c92f5fa3fd24125))
* End endpoint cleanup ([6b33978](https://github.com/browserbase/stagehand-net/commit/6b33978623eedce1b5579e705361c839ff2e0c9f))
* Include LLM headers in ModelConfig ([ea89f89](https://github.com/browserbase/stagehand-net/commit/ea89f897c49f86777b6f06edaba309f608bd94da))
* Include replay endpoint in stainless spec so SDK clients can get run metrics ([e9fdd89](https://github.com/browserbase/stagehand-net/commit/e9fdd89600606e06b760afd1dbff555d90691156))
* move Stainless compatibility transforms from gen-openapi.ts into stainless.yml ([7068824](https://github.com/browserbase/stagehand-net/commit/706882437b7438fada41642c4e27ce8c833c8ea8))
* randomize region used for evals, split out pnpm and turbo cache, veri… ([5c36c02](https://github.com/browserbase/stagehand-net/commit/5c36c027a72715dc394d4dc4482d309685abee10))
* Removed MCP from readme for now ([f173a80](https://github.com/browserbase/stagehand-net/commit/f173a80394811c28d64ea561b23050159ee47db0))
* Revert broken finished SSE yield config ([dcab6a5](https://github.com/browserbase/stagehand-net/commit/dcab6a549b3daaa2084b629633a462910a71df03))
* Update stainless.yml for project and publish settings ([5f7a786](https://github.com/browserbase/stagehand-net/commit/5f7a786bb55f3d2958af0335850c1de917bcb6e7))
* variables for observe ([6668a7e](https://github.com/browserbase/stagehand-net/commit/6668a7e4df2fb13c7463bd5a8d3417d716cf68db))


### Bug Fixes

* **client:** handle path params correctly in `FromRawUnchecked` ([29e411c](https://github.com/browserbase/stagehand-net/commit/29e411c157e2868886ff9e02c873f155b840b15c))
* **client:** handle root bodies in requests properly ([1c7654f](https://github.com/browserbase/stagehand-net/commit/1c7654f6dc8dae28bf5467d2e665d53a5e1e5d96))
* **client:** handle unions containing unknown types properly ([2a7576a](https://github.com/browserbase/stagehand-net/commit/2a7576aefd876d6dd2075a561e258c4e3cde14d8))
* **client:** improve behaviour for comma-delimited binary content in multipart requests ([63f7db5](https://github.com/browserbase/stagehand-net/commit/63f7db584e2dcccc2a4a8b0f159364656a50b695))
* **client:** improve union equality method ([e0a1678](https://github.com/browserbase/stagehand-net/commit/e0a167855a6540366efea3e2e7eccbc64b0065dd))
* **client:** validate unions properly ([087cc53](https://github.com/browserbase/stagehand-net/commit/087cc531de13193f6734cc77601826736099b68d))
* **docs:** make xml syntactically correct ([f3c68ef](https://github.com/browserbase/stagehand-net/commit/f3c68ef22883a20c2bdd5f5520a37608b5fd4b69))


### Chores

* change visibility of QueryString() and AddDefaultHeaders ([f655845](https://github.com/browserbase/stagehand-net/commit/f65584521843f75b3b90a1a2e8493bb51675c474))
* **ci:** skip lint on metadata-only changes ([a027bc6](https://github.com/browserbase/stagehand-net/commit/a027bc620f45a6ace517434e4cc71b42ac2fbb7b))
* **client:** update formatting ([721c480](https://github.com/browserbase/stagehand-net/commit/721c4807811f583802b2e44cab336d88ea8314b8))
* **docs:** add proxy documentation to readme ([1fd2998](https://github.com/browserbase/stagehand-net/commit/1fd299833ce513ec9a9ea19cd4febf5541b8ab0f))
* **docs:** add undocumented parameters to readme ([79503d8](https://github.com/browserbase/stagehand-net/commit/79503d8c88c73ad54cfe24e4daccb30a5ca1b502))
* **internal:** add copy constructor tests ([e4dcd96](https://github.com/browserbase/stagehand-net/commit/e4dcd96a44a62e54399d1cc139ec1e3d57fe8d88))
* **internal:** add sse tests ([3c2c701](https://github.com/browserbase/stagehand-net/commit/3c2c701a3b77eda43d11355abac59fb206b99645))
* **internal:** ignore stainless-internal artifacts ([a06a892](https://github.com/browserbase/stagehand-net/commit/a06a89244434cb9f952c1729d17956780c2f0629))
* **internal:** improve HttpResponse qualification ([b9f018b](https://github.com/browserbase/stagehand-net/commit/b9f018b477d27b215553c20028b02d0d81dbdc54))
* **internal:** remove mock server code ([5a63556](https://github.com/browserbase/stagehand-net/commit/5a63556e7d91e0ce5c43e1c5513741667cff67f3))
* **internal:** tweak CI branches ([8b75d2c](https://github.com/browserbase/stagehand-net/commit/8b75d2c36e9a79eab71076924b61fd59ec6d8e35))
* **internal:** update `actions/checkout` version ([bebf217](https://github.com/browserbase/stagehand-net/commit/bebf217c94e0cb86861f9308853c02dc281d9921))
* **internal:** update gitignore ([214f388](https://github.com/browserbase/stagehand-net/commit/214f38876701a414a7f4869cd20c3cf5899d8edc))
* **tests:** add tests for retry logic ([8666f41](https://github.com/browserbase/stagehand-net/commit/8666f41d3886eb08db10025a6d283ee199d27be4))
* update mock server docs ([7aac0ab](https://github.com/browserbase/stagehand-net/commit/7aac0ab0381d2903c5feac7554a2814e4ded175c))


### Refactors

* **internal:** default headers ([a6d9731](https://github.com/browserbase/stagehand-net/commit/a6d97313e053b7c8a593a7b3134fd75516a57c26))

## 3.0.2 (2026-01-16)

Full Changelog: [v3.0.1...v3.0.2](https://github.com/browserbase/stagehand-net/compare/v3.0.1...v3.0.2)

### Chores

* remove custom code ([dac677e](https://github.com/browserbase/stagehand-net/commit/dac677e38b31bc6fe2613712a4892b299ab1c2b6))

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
