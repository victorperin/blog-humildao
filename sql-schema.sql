-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.7-rc-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             9.2.0.4947
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for blog-humildao
CREATE DATABASE IF NOT EXISTS `blog-humildao` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `blog-humildao`;


-- Dumping structure for table blog-humildao.categorias
CREATE TABLE IF NOT EXISTS `categorias` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table blog-humildao.comentarios
CREATE TABLE IF NOT EXISTS `comentarios` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_post` int(10) unsigned NOT NULL,
  `id_usuario` int(10) unsigned NOT NULL,
  `conteudo` tinytext NOT NULL,
  PRIMARY KEY (`id`),
  KEY `comentario_post` (`id_post`),
  KEY `comentario_usuario` (`id_usuario`),
  CONSTRAINT `comentario_post` FOREIGN KEY (`id_post`) REFERENCES `posts` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `comentario_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table blog-humildao.posts
CREATE TABLE IF NOT EXISTS `posts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_usuario` int(10) unsigned NOT NULL,
  `titulo` varchar(256) NOT NULL,
  `conteudo` text,
  PRIMARY KEY (`id`),
  KEY `post_usuario` (`id_usuario`),
  CONSTRAINT `post_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table blog-humildao.posts_categorias
CREATE TABLE IF NOT EXISTS `posts_categorias` (
  `id_post` int(10) unsigned NOT NULL,
  `id_categoria` int(10) unsigned NOT NULL,
  KEY `categoria` (`id_categoria`),
  KEY `post` (`id_post`),
  CONSTRAINT `categoria` FOREIGN KEY (`id_categoria`) REFERENCES `categorias` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `post` FOREIGN KEY (`id_post`) REFERENCES `posts` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table blog-humildao.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL DEFAULT '0',
  `hash_senha` char(32) NOT NULL DEFAULT '0' COMMENT 'hash md5 da senha (concatenada com o salt)',
  `salt_senha` char(32) NOT NULL DEFAULT '0' COMMENT 'salt aleatório, para proteger a senha melhor (Saiba mais por aqui: http://blog.thiagobelem.net/encriptando-senhas-de-forma-segura/ )',
  `nome_exibicao` varchar(50) NOT NULL DEFAULT '0',
  `admin` tinyint(1) unsigned NOT NULL DEFAULT '0',
  `email` varchar(254) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
