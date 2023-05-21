Feature: BooksController
    In order to manage books
    As a user
    I want to add a book and get all books

Scenario Outline: Add book
    Given I have a book with name '<Name>' having cost of '<Price>' with genere '<Genere>'
    When I request all books
    Then I verified book is added with name '<Name>' having cost of '<Price>' with genere '<Genere>'

Examples: 
    | Name  | Price | Genere  |
    | Book1 | 100   | Horror  |
    | Book2 | 400   | Fanatcy |
