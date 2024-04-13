# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts
To install dependencies run:
### `npm install` in `Frontend` subfolder
In the project directory, you can run:

### `npm start` in `Frontend` subfolder

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

## TESTING only UI

Run mockserver using `docker-compose up` command in `mockserver` subfolder
It is running on 8080 port with dummy data from `initializerJson.json` file

## FORMATTING

`npx pretty-quick`

## CURRENT STATE:
Ugly app with empty components - ids of clicked items are displayed at the top of the page
It is using `redux-persist`, so user remembered data are stored after refresh
