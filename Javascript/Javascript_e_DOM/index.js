document.addEventListener("DOMContentLoaded", () => {
    loadData();
})

document.getElementById("formulario").addEventListener("submit", function(event) {
    event.preventDefault();

    var nome = document.getElementById("nome").value;
    var data = document.getElementById("data").value;

    adicionarLinha(nome, data);
    saveData();

});

function adicionarLinha(nome, data){
    var tabela = document.getElementById("tabela").getElementsByTagName("tbody")[0];

    var novaLinha = document.createElement("tr");
    var celulaNome = document.createElement("td");
    var celulaData = document.createElement("td");
    var celulaAcao = document.createElement("td");

    celulaNome.innerHTML = nome;
    celulaData.innerHTML = data;
    celulaAcao.innerHTML = "<button onclick=editarLinha(this.parentNode)>Editar</button><button onclick=deletarLinha(this.parentNode)>Deletar</button>";

    novaLinha.appendChild(celulaNome);
    novaLinha.appendChild(celulaData);
    novaLinha.appendChild(celulaAcao);

    tabela.appendChild(novaLinha);

}

function loadData(){
    var tabela = document.getElementById("tabela").getElementsByTagName("tbody")[0];
    var dadosArmazenados = JSON.parse(localStorage.getItem("dados")) || [];

    dadosArmazenados.forEach(dado => {
        adicionarLinha(dado.nome, dado.data);
    });
}

function saveData(){
    var tabela = document.getElementById("tabela").getElementsByTagName("tbody")[0];
    var dados = [];

    for(var i = 0; i < tabela.rows.length; i++){
        var nome = tabela.rows[i].cells[0].innerHTML;
        var data = tabela.rows[i].cells[1].innerHTML;
        dados.push({nome: nome, data: data});
    }

    localStorage.setItem("dados", JSON.stringify(dados));
}

function editarLinha(dados) {
    var linha = dados.parentNode;
    var colunas = linha.getElementsByTagName("td");


    var nomeNovo = prompt("Digite o novo nome");
    var dataNovo = prompt("Digite a nova data");

    colunas[0].innerHTML = nomeNovo;
    colunas[1].innerHTML = dataNovo;

    saveData();
}

function deletarLinha(dados){
    var tabela = document.getElementById("tabela").getElementsByTagName("tbody")[0];
    var linha = dados.parentNode;

    tabela.removeChild(linha);

    saveData();
}