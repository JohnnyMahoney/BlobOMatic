import pygame

def draw_grid(surface, width, height, deltax, deltay):
    for i in range(int(height / deltay)):
        pygame.draw.line(surface, (128, 128, 128), (0, i * deltay), (width, i * deltay))

    for i in range(int(width / deltax)):
        pygame.draw.line(surface, (128, 128, 128), (i * deltax, 0), (i * deltax, height))

    pygame.display.update()

def draw_point(surface, point, delta, color,  locked, nono):
    realpoint = (point[0] * delta[0], point[1] * delta[1])

    pygame.draw.circle(surface, color, realpoint, 20)

    locked[point[1] - 1][point[0] - 1] = 1

    try:
        nono[point[1] - 2][point[0] - 2] = 1
        nono[point[1] - 2][point[0] - 1] = 1
        nono[point[1] - 2][point[0]] = 1
        nono[point[1] - 1][point[0] - 2] = 1
        nono[point[1] - 1 ][point[0] - 1] = 1
        nono[point[1] - 1][point[0]] = 1
        nono[point[1]][point[0] - 2] = 1
        nono[point[1]][point[0] - 1] = 1
        nono[point[1]][point[0]] = 1
    except:
        pygame.time.delay(100)

    pygame.display.update()
    


   # [3][2] =    [x x x]
   #             [x x x]