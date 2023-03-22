export default [
    {
        context: [
            '/api'
        ],
        target: 'http://localhost:5224',
        secure: false,
        logLevel: "debug",
        pathRewrite: {
            "^/api": ""
        }
    }
];