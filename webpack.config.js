const webpack = require('webpack');

module.exports = {
  entry: './map.js',
  output: {
    path: __dirname,
    filename: 'webpackBundle.js'
  },
  module: {
    rules: [
        {
            test: /\.css$/,
            use: [
                'style-loader',
                'css-loader',
            ],
        },
    ],
  },
};