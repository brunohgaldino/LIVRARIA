//Listando os dados
Listar();

//FUNCOES

function Cadastrar() {
    //obter objeto do formulario
    var dadosSerializados = $('#formDados').serialize();

   
    $.ajax({
        //tipo de solicitação
        type: "POST",
        //url para onde enviaremos os dados
        url: "/App/Cadastrar",
        
        data: dadosSerializados,
        success: function () {
            //caso de certo
            alert("Cadastrado com Sucesso!");
            //chamar a listagem de dados
            Listar();
        },
        error: function () {
            Mensagem("danger", "Erro ao cadastrar!");
        }

    });

}

function Listar() {
    //Limpa todos os inputs
    LimparFormulario();

    
    $.ajax({
       //tipo de solicitação
        type: "GET",
        //url para onde enviaremos os dados
        url: "/App/Listar",
     
        success: function (dadoslivro) {

            if (dadoslivro != null) {

              
                $('#tbody').children().remove();

               
                $(dadoslivro).each(function (i) {

                   
                    var tbody = $('#tbody');
                 
                    var tr = "<tr>";
                    //adicionando os registros manualmente em sua posição
                    tr += "<td>" + dadoslivro[i].Id;
                    tr += "<td>" + dadoslivro[i].Titulo;
                    tr += "<td>" + dadoslivro[i].Autor;
                    tr += "<td>" + dadoslivro[i].Exemplar;

                    // criação dos botoes
                    tr += "<td>" + "<button class='btn btn-info' onclick=Editar(" + dadoslivro[i].Id + ")>" + "Editar";
                    tr += "<td>" + "<button class='btn btn-danger' onclick=Deletar(" + dadoslivro[i].Id + ")>" + "Deletar";

                    //a cada posicao, criamos a linha do TBODY com os dados
                    tbody.append(tr);



                });
            }
        }
    });
}

function Editar(id) {

    if (id != null && id > 0) {

        $.ajax({
            type: 'GET',
            url: '/App/Editar',
            data: { id: id },
            success: function (dados) {
               
                //valores
                $('#id').val(dados.Id);
                $('#Titulo').val(dados.Titulo);
                $('#Autor').val(dados.Autor);
                $('#Exemplar').val(dados.Exemplar);

                //quando for editar, esconder o salvar e exibir o atualizar
                $("#salvar").addClass("hidden");
                $("#atualizar").removeClass("hidden");
            }


        });
    }
}

function Atualizar() {

    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/App/Atualizar",
        data: dadosSerializados,
        success: function () {

            $("#salvar").removeClass("hidden");
            $("#atualizar").addClass("hidden");

            Listar();
        }

    });
}

function Deletar(id) {
    //Usando o CONFIRM do js, temos uma resposta booleana, caso true(clicar em OK), ele executa nossa funcao
    var confirmar = confirm("Deseja Realmente Apagar ?");
    if (confirmar) {

        if (id != null || id > 0) {
            $.ajax({
                type: 'POST',
                url: "/App/Deletar",
               // busca por id
                data: { id: id },
                success: function () {

                     // após remover com sucesso, faz a listagem
                    
                    alert("Deletado com Sucesso !");

                    Listar();
                }

            });

        }
    }
}

function LimparFormulario() {
    //Limpar formulario
    //pega todos os ítens do form e limpa
    $('#formDados').each(function () {
        this.reset();
    });
}


