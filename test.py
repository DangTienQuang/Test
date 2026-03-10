import socket

def test_req(val):
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.connect(('127.0.0.1', 3000))
    s.sendall(val.encode('utf-8'))
    data = s.recv(4096)
    s.close()
    print(f"Sent {val}, received: {data.decode('utf-8')}")

test_req("101")
test_req("103")
test_req("999")
