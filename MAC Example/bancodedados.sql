-- phpMyAdmin SQL Dump
-- version 4.7.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: 21-Maio-2020 às 20:40
-- Versão do servidor: 5.6.34
-- PHP Version: 5.6.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bancodedados`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `clientes`
--

CREATE TABLE `clientes` (
  `id` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `Sobrenome` varchar(45) NOT NULL,
  `Documentos` varchar(20) DEFAULT NULL,
  `Telefone` varchar(12) DEFAULT NULL,
  `Conta` double(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `estoque`
--

CREATE TABLE `estoque` (
  `id` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `Descricao` varchar(45) DEFAULT NULL,
  `Validade` date NOT NULL,
  `Preco` double(10,2) NOT NULL,
  `Quantidade` int(3) NOT NULL,
  `Cardapio` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `fecharmesa`
--

CREATE TABLE `fecharmesa` (
  `id` int(11) NOT NULL,
  `Nome` varchar(45) DEFAULT NULL,
  `Pagamento` varchar(45) DEFAULT NULL,
  `ValorTotal` double(10,2) DEFAULT NULL,
  `Dividir` varchar(45) DEFAULT NULL,
  `Pago` int(1) NOT NULL,
  `Data` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `mesa`
--

CREATE TABLE `mesa` (
  `id` int(11) NOT NULL,
  `Codigo` varchar(10) DEFAULT NULL,
  `Status` int(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `vendas`
--

CREATE TABLE `vendas` (
  `id` int(11) NOT NULL,
  `Mesa` varchar(5) DEFAULT NULL,
  `Produto` varchar(45) DEFAULT NULL,
  `Preco` double(10,2) DEFAULT NULL,
  `Quantidade` int(2) DEFAULT NULL,
  `Data` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `estoque`
--
ALTER TABLE `estoque`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `fecharmesa`
--
ALTER TABLE `fecharmesa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mesa`
--
ALTER TABLE `mesa`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vendas`
--
ALTER TABLE `vendas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `estoque`
--
ALTER TABLE `estoque`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT for table `fecharmesa`
--
ALTER TABLE `fecharmesa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT for table `mesa`
--
ALTER TABLE `mesa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `vendas`
--
ALTER TABLE `vendas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
