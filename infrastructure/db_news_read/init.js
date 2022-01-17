db.auth('admin', 'admin')

db = new Mongo().getDB("breakingnews");

db.createUser({
    'user': "user",
    'pwd': "user",
    'roles': [{
        'role': 'readWrite',
        'db': 'breakingnews'
    }]
});

db.createCollection('news');
