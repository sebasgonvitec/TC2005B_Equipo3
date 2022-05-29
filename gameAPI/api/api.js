"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5000

app.use(express.json())

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

//Create connection to database
async function connectToDB()
{
    return await mysql.createConnection({
        host:'localhost',
        user:'AsleepDevelop',
        password:'quieroamiT0p0',
        database:'asleep_db'
    })
}

// Get root page (main crud html)
app.get('/', (request,response)=>{
    fs.readFile('./html/crud_index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

// USERS TABLE --------------------------------------------------------------------------------
// get users table 
app.get('/api/users', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from users')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a user from specific id 
app.get('/api/users/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from users where id_user= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for users table
app.post('/api/users', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into users set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for users table
app.put('/api/users', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update users set username= ?, user_password= ?, num_levels_created= ?, first_connection= ?, last_connection= ? where id_user= ?', 
        [request.body['username'], 
        request.body['user_password'],
        request.body['num_levels_created'], 
        request.body['first_connection'],
        request.body['last_connection'],
        request.body['id_user']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Delete a user with certain id
app.delete('/api/users/:id', async (request, response)=>{

    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('delete from users where id_user= ?', [request.params.id])
        response.json({'message': "Data deleted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// LEVEL TABLE ------------------------------------------------------------------------
// get level table 
app.get('/api/levels', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from levels')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a level from specific id 
app.get('/api/levels/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from levels where id_level= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for levels table
app.post('/api/levels', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into levels set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for levels table
app.put('/api/levels', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update levels set id_user= ?, level_name= ?, level_file= ?, level_time= ?, num_times_played= ?, num_items= ? where id_level= ?', 
        [request.body['id_user'], 
        request.body['level_name'],
        request.body['level_file'], 
        request.body['level_time'],
        request.body['num_times_played'],
        request.body['num_items'],
        request.body['id_level']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Delete a level with certain id
app.delete('/api/levels/:id', async (request, response)=>{

    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('delete from levels where id_level= ?', [request.params.id])
        response.json({'message': "Data deleted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// RATING TABLE ------------------------------------------------------------------------
// get level table 
app.get('/api/ratings', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from ratings')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a level from specific id 
app.get('/api/ratings/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from ratings where id_rating= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for levels table
app.post('/api/ratings', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into ratings set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for levels table
app.put('/api/ratings', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update ratings set id_user= ?, id_level= ?, rating= ? where id_rating= ?', 
        [request.body['id_user'], 
        request.body['id_level'],
        request.body['rating'],
        request.body['id_rating']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Delete a level with certain id
app.delete('/api/ratings/:id', async (request, response)=>{

    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('delete from ratings where id_rating= ?', [request.params.id])
        response.json({'message': "Data deleted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})



// GAMEPLAY TABLE ------------------------------------------------------------------------

// get gamplay table 
app.get('/api/gameplays', async (request, response)=>{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from gameplays')
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Get a level from specific id 
app.get('/api/gameplays/:id', async (request, response)=>
{
    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('select * from gameplays where id_gameplay= ?', [request.params.id])
        response.json(results)
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Post for levels table
app.post('/api/gameplays', async (request, response)=>{

    let connection = null

    try
    {    
        connection = await connectToDB()
        const [results, fields] = await connection.query('insert into gameplays set ?', request.body)
        response.json({'message': "Data inserted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})


// Put/Update for levels table
app.put('/api/gameplays', async (request, response)=>{

    let connection = null

    try{
        connection = await connectToDB()
        const [results, fields] = await connection.query('update gameplays set id_user= ?, id_level= ?, time_elapsed= ? where id_gameplay= ?', 
        [request.body['id_user'], 
        request.body['id_level'],
        request.body['time_elapsed'],
        request.body['id_gameplay']])

        response.json({'message': "Data updated correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

//Delete a level with certain id
app.delete('/api/gameplays/:id', async (request, response)=>{

    let connection = null

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.query('delete from gameplays where id_gameplay= ?', [request.params.id])
        response.json({'message': "Data deleted correctly."})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})