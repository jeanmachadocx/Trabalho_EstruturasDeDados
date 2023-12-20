<h1>README - Sistema de Gerenciamento de Processo Seletivo </h1>
<h3>Descrição</h3>
Este programa foi desenvolvido para gerenciar o processo seletivo da Universidade Stark. Ele automatiza a seleção de candidatos com base em suas notas e preferências de curso, gerenciando vagas disponíveis e filas de espera. O sistema calcula a média das notas dos candidatos em Redação, Matemática e Linguagens, e utiliza critérios de desempate baseados na nota de Redação.

<h3>Funcionalidades</h3>
Leitura de dados dos cursos e candidatos de um arquivo de entrada.
Cálculo da média das notas para cada candidato.
Seleção de candidatos com base na média de notas e critérios de desempate.
Alocação de candidatos em suas opções de curso preferenciais ou em filas de espera.
Geração de um arquivo de saída com a lista de candidatos selecionados e filas de espera, incluindo notas de corte para cada curso. <br>
Utilização de estruturas de dados como: Dictionary, Lista, Fila Flexível. <br>
Algoritmo de ordenação: Mergesort. Escolhido devido a sua boa complexidade e performance.

<h3>Formato do Arquivo de Entrada (entrada.txt)</h3>

A primeira linha contém dois inteiros N e M:
N: Número de cursos.
M: Número de candidatos.
As próximas N linhas contêm informações dos cursos, separadas por ponto e vírgula:
Código do curso (inteiro), nome do curso (string), quantidade de vagas (int).
As próximas M linhas contêm informações dos candidatos, separadas por ponto e vírgula:
Nome do candidato (string), nota de Redação (double), nota de Matemática (double), nota de Linguagens (double), código da primeira opção de curso (int), código da segunda opção de curso (int).

<h3>Formato do Arquivo de Saída (saida.txt)</h3>

Para cada curso, em ordem de entrada, uma linha com o nome do curso e a nota de corte.
Linha com a string “Selecionados”.
Lista de candidatos selecionados com nome e nota média, em ordem decrescente de nota.
Linha com a string “Fila de Espera”.
Lista de candidatos na fila de espera com nome e nota média, em ordem decrescente de nota.
Uma linha em branco após o último nome da fila de espera de cada curso <br>

<h3>Como executar?</h3>
O primeiro passo é criar os arquivos txt de entrada e saida no diretório: \\C:\AED Logo em seguida copie o modelo de entrada.txt que está no github. Pronto, você já poderá executar o projeto.




