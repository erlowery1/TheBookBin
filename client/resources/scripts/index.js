//gets all books from inventory and puts them in a table format
function getBooks(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover make it formatted*/
        let html = "<table id = \"myTable\" class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th onclick = \"sortTable(0)\">ID</th><th onclick = \"sortTable(1)\">ISBN</th><th onclick = \"sortTable(2)\">Title</th><th onclick = \"sortTable(3)\">Author</th><th onclick = \"sortTable(4)\">Genre</th><th onclick = \"sortTable(5)\">Price</th></tr>"
        json.forEach((book) => {
            html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>" + "<td>" + "$" + book.price + "</td>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//gets all books from inventory and prints them out, along with a corresponding delete button
function getBooksToDelete(){
    const allBooksApiUrl = "https://localhost:5001/api/books";

    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Delete</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
            "<td><button onclick = \"deleteBook("+book.id+")\">Delete</button></td></tr>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("delete").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//adds a book to the books table
function postBook(){
    const postBookApiUrl = "https://localhost:5001/api/books";
    //getting the readlines from the website when a user adds a book
    const bookTitle = document.getElementById("title").value;
    const bookAuthor = document.getElementById("author").value;
    const bookIsbn = document.getElementById("isbn").value;
    const bookGenre = document.getElementById("genre").value;
    const bookPrice = document.getElementById("price").value;

    //make call to the backend, pass it the data, and make it do its thing
    fetch(postBookApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }, //sending our data
        body:JSON.stringify({
            isbn: parseInt(bookIsbn),
            title: bookTitle,
            author: bookAuthor,
            genre: bookGenre,
            price: parseFloat(bookPrice)
        })
    })
    .then((response)=>{
        console.log(response);
        getBooks();
    })
}

//deletes book from the inventory database
deleteBook = function(id){
    console.log(id);
    //it needs to get an id so the controller knows which to delete
    const deleteBookApiUrl = "https://localhost:5001/api/books/" + id;
    //getting the readlines from the website when a user adds a book

    //make call to the backend, pass it the data, and make it run the delete
    fetch(deleteBookApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        console.log(response);
        getBooksToDelete();
    })
}

//used to search all available books and put matching results in a table format
function search(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th></tr>"
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search)(
                html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>" + book.genre + "</td>" + "<td>" + "$" + book.price + "</td>"
            )
            
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("books").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//used to search all available books and put matching results in a table format along with a delete button
function searchDelete(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Delete</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search)(
                html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
                "<td><button onclick = \"deleteBook("+book.id+")\">Delete</button></td></tr>"
            )
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("delete").innerHTML = html;
    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

function sortTable(n) {
    var table,
      rows,
      switching,
      i,
      x,
      y,
      shouldSwitch,
      dir,
      switchcount = 0;
    table = document.getElementById("myTable");
    switching = true;
    //Set the sorting direction to ascending:
    dir = "asc";
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
      //start by saying: no switching is done:
      switching = false;
      rows = table.getElementsByTagName("tr");
      /*Loop through all table rows (except the
      first, which contains table headers):*/
      for (i = 1; i < rows.length - 1; i++) { //Change i=0 if you have the header th a separate table.
        //start by saying there should be no switching:
        shouldSwitch = false;
        /*Get the two elements you want to compare,
        one from current row and one from the next:*/
        x = rows[i].getElementsByTagName("TD")[n];
        y = rows[i + 1].getElementsByTagName("TD")[n];
        /*check if the two rows should switch place,
        based on the direction, asc or desc:*/
        if (dir == "asc") {
          if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
            //if so, mark as a switch and break the loop:
            shouldSwitch = true;
            break;
          }
        } else if (dir == "desc") {
          if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
            //if so, mark as a switch and break the loop:
            shouldSwitch = true;
            break;
          }
        }
      }
      if (shouldSwitch) {
        /*If a switch has been marked, make the switch
        and mark that a switch has been done:*/
        rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
        switching = true;
        //Each time a switch is done, increase this count by 1:
        switchcount++;
      } else {
        /*If no switching has been done AND the direction is "asc",
        set the direction to "desc" and run the while loop again.*/
        if (switchcount == 0 && dir == "asc") {
          dir = "desc";
          switching = true;
        }
      }
    }
}

//finds the total of the inputted book and presents it to the screen
function getTotal(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    let html = 0.0;
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search){
                 html = "$" + book.price;
                 console.log("price" + book.price);
            }
        
        });
        //error handing if no matching book was found
        if(html == 0.0){
            html = "Sorry! That was not a valid ISBN/Title. Please try again.";
        }
        document.getElementById("total").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//used to sell a book// /sales + id
function bookTotal(){
    //need to change this to the transactions api
    //const proxyurl = "https://cors-anywhere.herokuapp.com/";
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const allTransactionsApiUrl = "https://localhost:5001/api/books/sales";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search){
                 const price = book.price;
                 console.log(price);
                 const id = book.id;
                 const isbn = book.isbn;
                 const title = book.title;
                 const author = book.author;
                 const genre = book.genre;
                 const name = document.getElementById("custName").value;
                 deleteBook(id);

                 fetch(allTransactionsApiUrl, {
                    method: "POST",
                    headers: {
                        "Accept": 'application/json',
                        "Content-Type": 'application/json',
                    },
                    body:JSON.stringify({
                        
                        price: parseFloat(price),
                        id: id,
                        isbn: isbn,
                        title: title,
                        author: author,
                        genre: genre,
                        name: name
                    })
                })
                .then((response)=>{
                    console.log(response);
                })
            }
        
        });
        //target that html element and set it equal to html
        // need to make it where the price appears at the html div
        // document.getElementById("total").innerHTML = price;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//gets all books and prints to screen, along with a corresponding edit button for each
function getBooksToEdit(){
    const allBooksApiUrl = "https://localhost:5001/api/books";

    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Edit</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
            "<td><button onclick = \"editBook("+book.id+")\">Edit</button></td></tr>";
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("edit").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}

//searches all books and puts every matching result in a table along with a corresponding edit button
function searchEdit(){
    const allBooksApiUrl = "https://localhost:5001/api/books";
    const search = document.getElementById("search").value.toLowerCase(); //to lower makes it not case sensitive
    //whatever comes back from allbookspaiurl will go back as the response for the then
    fetch(allBooksApiUrl).then(function(response){
        console.log(response);
        //turn response into a json object we can deal with 
        return response.json();
    }).then(function(json){
        /*border and hover are built into bootstrap and make it prettier*/
        let html = "<table class = \"table-bordered table-hover\">";
        /*adding the table row and table headers*/
        html +="<tr><th>ID</th><th>ISBN</th><th>Title</th><th>Author</th><th>Genre</th><th>Price</th><th>Edit</th></tr>"
        //add each book to the table, including a delete button that links to the delete book method
        json.forEach((book) => {
            if (book.title.toLowerCase() == search || book.isbn == search)(
                html += "<tr><td>" + book.id + "</td><td>" + book.isbn + "</td><td>" + book.title + "</td><td>"+ book.author + "</td><td>"+ book.genre + "</td><td>"+ book.price + "</td>" + 
                "<td><button onclick = \"editBook("+book.id+")\">Edit</button></td></tr>"
            )
        });
        html += "</table>";
        //target that html element and set it equal to html
        document.getElementById("edit").innerHTML = html;

    }).catch(function(error){ //catch any errors
        console.log(error);
    })
}




