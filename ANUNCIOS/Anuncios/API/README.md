### Implementação

Iniciei a implementação pelo WebCrawler. Lendo a pagina HTML para extrair as informações básicas do anúnicio.

Passei em seguida a implementar a primeira parte da API para requisitar a leitura e armazenamento dos anúncios.

Em seguida já disponibilizei o endpoint de consulta dos anúncios armazenados no banco dados. Como base, escolhi o MongoDb, pela praticidade de armazenar documentos JSON e minha familiaridade pessoal. Também optei por ele pois o desafio não exige muitos relacionamentos em banco de dados.

Como parte final, implementei a parte restritiva, a qual pedia que fosse criado um fluxo de criação e restrição à API por Login.  

### Utilizando

A api tem o seguinte funcionamento:

* `/api/users` cria usuários, por exemplo: 

`{
    "Login":"lucas", 
    "Password":"1234"
}`

* `/api/login` deixa o usuário logado e disponibilizar as outras funcionalidades da API. Este endpoint espera no body um `Usuário`.

* `/api/readads` lê os anúncios da página da OLX e grava-os num banco de dados para posterior consulta.

* `/api/ads` lê da base de dados os anúncios e os retorna em forma de listagem.