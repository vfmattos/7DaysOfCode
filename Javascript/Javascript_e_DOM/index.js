var tabela = document.getElementById("tabela").getElementsByTagName("tbody")[0];


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

    var novaLinha = document.createElement("tr");
    var celulaNome = document.createElement("td");
    var celulaData = document.createElement("td");
    var celulaAcao = document.createElement("td");

    celulaNome.innerHTML = nome;
    celulaData.innerHTML = data;
    celulaAcao.innerHTML = "<button onclick=editarLinha(this.parentNode) class=\"Editar\">Editar</button><button onclick=deletarLinha(this.parentNode) class=\"Apagar\">Deletar</button>";

    novaLinha.appendChild(celulaNome);
    novaLinha.appendChild(celulaData);
    novaLinha.appendChild(celulaAcao);

    tabela.appendChild(novaLinha);

}

function loadData(){
    var dadosArmazenados = JSON.parse(localStorage.getItem("dados")) || [];

    dadosArmazenados.forEach(dado => {
        adicionarLinha(dado.nome, dado.data);
    });
}

function saveData(){
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


    var nomeNovo = obterNomeValido();
    var dataNovo = obterDataValida();

    colunas[0].innerHTML = nomeNovo;
    colunas[1].innerHTML = dataNovo;

    saveData();
}

function obterNomeValido(){
    var nome;
    do{
        nome = prompt("Digite o nome (Apenas letras):");
    }while(!validarNome(nome));

    return nome;
}

function obterDataValida(){
    var data;
    do{
        data = prompt("Digite a data (dd/mm/aaaa):");
    }while(!validarData(data));

    return data;
}

function validarNome(nome){
    var regex = /^[a-zA-Z\s]+$/;

    if(!regex.test(nome)){
        alert("Digite apenas letras!");
    }

    return regex.test(nome);
}

function validarData(data){
    var regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;

    if(!regex.test(data)){
        alert("Formato de data inválida!");
    }

    return regex.test(data);
}

function deletarLinha(dados){
    var linha = dados.parentNode;

    tabela.removeChild(linha);

    saveData();
}

var header = document.getElementsByClassName("cabecalho")[0];
window.onscroll = function() {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        if (window.innerWidth > 820) {
            header.classList.add('scrolled');
        }
    } else {
        header.classList.remove('scrolled');
    }
};