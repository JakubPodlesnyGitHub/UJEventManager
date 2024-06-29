const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: './src/index.js',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'dist'),
        publicPath: process.env.REACT_APP_BASE_URL || '/'
    },
    devServer: {
        static: {
            directory: path.resolve(__dirname, 'dist'),
        },
        open: true,
        host: '0.0.0.0',
        allowedHosts: 'all',
        port: 3000,
        // port: 80,
        historyApiFallback: {
            index: process.env.REACT_APP_BASE_URL || '/'
        }
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: './public/index.html',
        }),
        // new webpack.DefinePlugin({
        //     'process.env.REACT_APP_BASE_URL': JSON.stringify(process.env.REACT_APP_BASE_URL)
        //   })
    ],
    module: {
        rules: [
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                },
            },
            {
                test: /\.(png|svg|jpg|gif|svg|json|ico)$/,
                use: ['file-loader']
              }
        ],
    },
    resolve: {
        extensions: ['.js', '.jsx'],
    },
};
