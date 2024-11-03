﻿using Core.DTOs;

public class CarrinhoCreateDTO
{
    public string UsuarioId { get; set; }
    public ICollection<ProdutoItemDTO> Produtos { get; set; }
}

public class CarrinhoUpdateDTO
{
    public ICollection<ProdutoItemDTO> Produtos { get; set; }
}